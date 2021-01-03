using System.ComponentModel;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace UserStories
{
    using Library;

    class UserStoryViewer : EditorWindow
    {

        [MenuItem(Settings.MENU_ITEM_DISPLAYER)]
        static void ShowWindow()
        {
            var window = GetWindow<UserStoryViewer>();
            window.titleContent = new GUIContent(Settings.MENU_TITLE);
            UpdateContainer();
            window.Show();
        }

        private static void UpdateContainer()
        {
            Containers = new List<UserStoryContainer>();
            List<UserStory> stories = Unity.GetAssets<UserStory>(Settings.DEFAULT_CATALOG);
            UserStoryCategory[] category = Unity.GetAssets<UserStoryCategory>(Settings.DEFAULT_CATALOG).ToArray();
            foreach (var cat in category)
            {
                Containers.Add(new UserStoryContainer(cat, stories.FindAll(x => x.Category == cat)));
            }
            var temp = show;
            show = new bool[Containers.Count];
            for (int i = 0; i < temp.Length; i++)
            {
                show[i] = temp[i];
            }
        }

        private static List<UserStoryContainer> Containers;
        private static bool[] show = new bool[1];

        private void OnGUI()
        {
            UpdateContainer();

            for (int i = 0; i < Containers.Count; i++)
            {
                DisplayCategory(Containers[i]);
                show[i] = EditorGUILayout.Foldout(show[i], "Show");
                foreach (var story in Containers[i].Stories)
                {
                    if (show[i])
                    {
                        ShowStoriesOfCategory(story);
                    }
                }
            }
        }

        private static void ShowStoriesOfCategory(UserStory story)
        {
            GUILayout.BeginVertical();
            GUILayout.BeginScrollView(Vector2.zero);
            SerializedObject so = new SerializedObject(story);
            EditorGUILayout.ObjectField(so.targetObject, typeof(UserStory), allowSceneObjects: false);
            EditorGUILayout.PropertyField(so.FindProperty("Request"));
            EditorGUILayout.PropertyField(so.FindProperty("WhyRequested"));
            EditorGUILayout.PropertyField(so.FindProperty("Answer"));
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
            EditorGUILayout.Separator();
        }

        private static void DisplayCategory(UserStoryContainer container)
        {
            EditorGUILayout.Separator();
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(container.Category.Name);
            EditorGUILayout.ObjectField(container.Category, typeof(UserStoryCategory), allowSceneObjects: false);
            GUILayout.EndHorizontal();
            try
            {
                Color CategoryColor = container.Category.TextColor;
                EditorGUI.DrawRect(GUILayoutUtility.GetRect(0.0f, 2.0f, GUILayout.ExpandWidth(true)), CategoryColor);
            }
            catch
            {
                EditorGUI.DrawRect(GUILayoutUtility.GetRect(0.0f, 2.0f, GUILayout.ExpandWidth(true)), new Color(255, 255, 255, 1));
            }

        }
    }
}

