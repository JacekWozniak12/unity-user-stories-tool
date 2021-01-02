namespace UserStories
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(UserStory))]
    public class UserStoryInspector : Editor
    {
        SerializedObject SerializedUserStory;
        SerializedProperty Request;
        SerializedProperty WhyRequested;
        SerializedProperty Answer;
        SerializedProperty Category;
        SerializedProperty CategoryColor;

        private void OnEnable()
        {
            SerializedUserStory = serializedObject;
            Category = serializedObject.FindProperty("Category");
            Request = serializedObject.FindProperty("Request");
            WhyRequested = serializedObject.FindProperty("WhyRequested");
            Answer = serializedObject.FindProperty("Answer");
        }

        public override void OnInspectorGUI()
        {
            SerializedUserStory.Update();
            EditorGUILayout.PropertyField(this.Category);
            DisplayCategoryColor();
            EditorGUILayout.PropertyField(Request);
            EditorGUILayout.PropertyField(WhyRequested);
            EditorGUILayout.PropertyField(Answer);
            SerializedUserStory.ApplyModifiedProperties();
        }

        private void DisplayCategoryColor()
        {
            SerializedObject Category = new SerializedObject(this.Category.objectReferenceValue);
            CategoryColor = Category.FindProperty("TextColor");
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(0.0f, 2.0f, GUILayout.ExpandWidth(true)), CategoryColor.colorValue);
        }
    }
}