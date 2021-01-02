namespace UserStories
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(UserStory))]
    public class UserStoryInspector : Editor
    {
        SerializedObject Object;
        SerializedProperty Request;
        SerializedProperty WhyRequested;
        SerializedProperty Answer;
        SerializedProperty Category;

        private void OnEnable()
        {
            Object = serializedObject;
            Category = serializedObject.FindProperty("Category");
            Request = serializedObject.FindProperty("Request");
            WhyRequested = serializedObject.FindProperty("WhyRequested");
            Answer = serializedObject.FindProperty("Answer");
        }

        public override void OnInspectorGUI()
        {
            Object.Update();
            EditorGUILayout.PropertyField(Category);
            EditorGUILayout.PropertyField(Request);
            EditorGUILayout.PropertyField(WhyRequested);
            EditorGUILayout.PropertyField(Answer);
            Object.ApplyModifiedProperties();
        }

    }
}