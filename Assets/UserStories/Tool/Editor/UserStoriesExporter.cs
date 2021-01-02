namespace UserStories
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    class UserStoriesEditor : EditorWindow
    {
        private UserStoriesMain main = UserStoriesMain.Instance;

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
            int length = main.UserStoriesContainers.Count;
            for (int i = 0; i < length; i++)
            {
                DisplayContainer(main.UserStoriesContainers[i]);
            }
            DisplayButtons();
        }

        private void Export()
        {
            string path = EditorUtility.SaveFilePanel("Save User Story Archives", Application.dataPath, "User-Stories", "uscx");
            if (path.Length == 0) return;
            UserStoriesIO.ExportContainerToJSON(main.UserStoriesContainers, path);
        }

        private void Import()
        {
            string path = EditorUtility.OpenFilePanel("Get User Story Archives", Application.dataPath, "uscx");
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

        private void DisplayContainer(UserStoryContainer userStoryContainer)
        {
            // GUI.contentColor = userStoryContainer.Category.Color;
            EditorGUILayout.LabelField(userStoryContainer.Category.Name);
            EditorGUILayout.LabelField(userStoryContainer.Category.Description);

            userStoryContainer.Stories.ForEach(x =>
            {
                DisplayUserStory(x);
            });
        }

        private void DisplayUserStory(UserStory userStory)
        {
            EditorGUILayout.LabelField(userStory.Category.Name);


            userStory.Request = EditorGUILayout.TextField("Request", userStory.Request);
            userStory.WhyRequested = EditorGUILayout.TextField("WhyRequested", userStory.WhyRequested);
            userStory.Answer = EditorGUILayout.TextField("Answer", userStory.Answer);
            
        }
    }
}