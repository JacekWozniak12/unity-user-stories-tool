namespace UserStories
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    class UserStoriesEditor : EditorWindow
    {
        private UserStoriesMain main = UserStoriesMain.Instance;
        private List<SerializedObject> SerializedContainers;

        [MenuItem(Settings.MENU_ITEM_DISPLAYER)]
        static void ShowWindow()
        {
            var window = GetWindow<UserStoriesEditor>();
            window.titleContent = new GUIContent("User Stories");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("User Stories", EditorStyles.boldLabel);
            SerializedContainers = new List<SerializedObject>();

            DisplayButtons();
        }

        private void Export()
        {
            string path = EditorUtility.SaveFilePanel("Save User Story Archives", Application.dataPath, "User-Stories", "json");
            if (path.Length == 0) return;
            UserStoriesIO.ExportContainerToJSON(main.UserStoriesContainers, path);
        }

        private void Import()
        {
            string path = EditorUtility.OpenFilePanel("Get User Story Archives", Application.dataPath, "json");
            if (path.Length == 0) return;

            List<UserStoryContainer> list = UserStoriesIO.LoadContainerFromJSON(path);
            if (list != null) main.UserStoriesContainers = list;
            Repaint();
        }

        private void DisplayButtons()
        {
            if (GUILayout.Button("Import")) Import();
            if (GUILayout.Button("Export")) Export();
        }
    }
}
