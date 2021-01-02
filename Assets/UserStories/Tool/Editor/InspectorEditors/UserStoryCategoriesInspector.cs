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
            EditorGUILayout.PropertyField(Name);
            EditorGUILayout.PropertyField(Description);
            EditorGUILayout.PropertyField(TextColor);
            EditorGUILayout.LabelField("UserStories", EditorStyles.boldLabel);
            
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginScrollView(Vector2.zero);
            foreach (var item in Container.Stories)
            {
                var so = new SerializedObject(item as UnityEngine.Object);
                EditorGUILayout.ObjectField(item, typeof(UserStory), allowSceneObjects: false);
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            SerializedUserCategory.ApplyModifiedProperties();
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