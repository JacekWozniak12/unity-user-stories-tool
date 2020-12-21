using System.ComponentModel;
using System.Net.Mime;
namespace UserStories
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    [CustomEditor(typeof(UserStoryCategory))]
    public class UserStoryCategoriesInspector : Editor
    {

        SerializedObject Object;
        SerializedProperty Name;
        SerializedProperty Description;
        SerializedProperty TextColor;
        UserStoryContainer Container;

        private void OnEnable()
        {
            Object = serializedObject;
            Name = serializedObject.FindProperty("Name");
            Description = serializedObject.FindProperty("Description");
            TextColor = serializedObject.FindProperty("TextColor");
            FindAllUserStoriesWithCategory();
        }

        public override void OnInspectorGUI()
        {
            Object.Update();
            EditorGUILayout.PropertyField(Name);
            EditorGUILayout.PropertyField(Description);
            EditorGUILayout.PropertyField(TextColor);
            
            EditorGUILayout.BeginScrollView(Vector2.zero);
            foreach(var Story in Container.Stories)
            {
                EditorGUILayout.LabelField(Story.Request);
            }
            EditorGUILayout.EndScrollView();

            Object.ApplyModifiedProperties();
        }

        private void FindAllUserStoriesWithCategory()
        {
            string[] UserStoriesGUID = AssetDatabase.FindAssets("t:UserStory", new[] { Settings.DEFAULT_CATALOG });
            List<UserStory> UserStories = new List<UserStory>();

            foreach (string GUID in UserStoriesGUID)
            {
                UserStory us = AssetDatabase.LoadAssetAtPath<UserStory>(AssetDatabase.GUIDToAssetPath(GUID));
                if (Object.targetObject == us.Category) UserStories.Add(us);
            }

            Container = new UserStoryContainer(Object.targetObject as UserStoryCategory, UserStories);
        }
    }
}