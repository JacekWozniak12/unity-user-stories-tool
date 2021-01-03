namespace UserStories
{
    using UnityEngine;
    using Library;
    using UnityEditor;
    using System.Collections.Generic;

    [CustomEditor(typeof(UserStoryCategory))]
    public class UserStoryCategoriesInspector : Editor
    {
        SerializedObject SerializedUserCategory;
        SerializedProperty Name;
        SerializedProperty Description;
        SerializedProperty TextColor;
        UserStoryContainer Container;


        private void OnEnable()
        {
            SerializedUserCategory = serializedObject;
            Name = serializedObject.FindProperty("Name");
            Description = serializedObject.FindProperty("Description");
            TextColor = serializedObject.FindProperty("TextColor");
            FindAllUserStoriesWithCategory();
        }

        public override void OnInspectorGUI()
        {
            SerializedUserCategory.Update();
            DisplayProperties();
            DisplayUserStoriesOfCategory();
            SerializedUserCategory.ApplyModifiedProperties();
        }

        private void DisplayProperties()
        {
            EditorGUILayout.PropertyField(Name);
            EditorGUILayout.PropertyField(Description);
            EditorGUILayout.PropertyField(TextColor);
        }

        private void DisplayUserStoriesOfCategory()
        {
            EditorGUILayout.LabelField("UserStories", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginScrollView(Vector2.zero);
            foreach (var item in Container.Stories)
            {
                EditorGUILayout.LabelField(item.Request, EditorStyles.largeLabel);
                EditorGUILayout.ObjectField(item, typeof(UserStory), allowSceneObjects: false);
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }

        private void FindAllUserStoriesWithCategory()
        {
            List<UserStory> stories = new List<UserStory>();
            stories.AddRange(Unity.GetAssets<UserStory>(new string[] { Settings.DEFAULT_CATALOG }));
            stories = stories.FindAll(x => x.Category == SerializedUserCategory.targetObject);
            Container = new UserStoryContainer(SerializedUserCategory.targetObject as UserStoryCategory, stories);

        }
    }
}