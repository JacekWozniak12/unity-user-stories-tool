namespace UserStories
{
    using UnityEngine;
    using UnityEditor;

    public class UserStoriesCreator : ScriptableWizard
    {
        private UserStoriesMain main = UserStoriesMain.Instance;
        public UserStory currentStory;

        [MenuItem(Settings.MENU_ITEM_CREATOR)]
        static void MenuEntryCall()
        {
            DisplayWizard<UserStoriesCreator>("UserStoriesCreator", "CreateStory");
        }
        
        void OnWizardCreate()
        {
            main.FindContrainerForCreatedUserStoryAndAdd(currentStory);
        }
                
    }
}