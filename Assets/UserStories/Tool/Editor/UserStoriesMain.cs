namespace UserStories
{
    using System.Collections.Generic;
    using Library;
    using UnityEngine;

    /// <summary>
    /// Main object to handle User Story App. Access by using Instance property.
    /// </summary>
    public class UserStoriesMain
    {
        private UserStoriesMain()
        {
            RefreshContainer();
        }

        public void FindAllUserStories()
        {
            RefreshContainer();

            List<UserStoryCategory> UserStoryCategories = new List<UserStoryCategory>();
            List<UserStory> UserStories = new List<UserStory>();
            UserStories.AddRange(Unity.GetAssets<UserStory>(new string[] { Settings.DEFAULT_CATALOG }));
            UserStoryCategories.AddRange(Unity.GetAssets<UserStoryCategory>(new string[] { Settings.DEFAULT_CATALOG }));

            foreach (var category in UserStoryCategories)
            {
                var stories = UserStories.FindAll(x => x.Category == category);
                UserStoriesContainers.Add(new UserStoryContainer(category, stories));
            }
        }

        private void RefreshContainer()
        {
            UserStoriesContainers = new List<UserStoryContainer>();
        }

        public void Update()
        {

        }

        public bool FindContrainerForCreatedUserStoryAndAdd(UserStory story)
        {
            UserStoryContainer container = UserStoriesContainers.Find(x => x.Category == story.Category);
            if (container != null)
            {
                container.Add(story, true);
                return true;
            }
            else if (container == null)
            {
                AddContainerToList(story);
                return true;
            }
            return false;
        }

        private void AddContainerToList(UserStory story)
        {
            UserStoryContainer container = new UserStoryContainer(story.Category, new List<UserStory>());
            if (!FindIfUserStoryExists(story)) container.Add(story);
            UserStoriesContainers.Add(container);
        }

        public bool FindIfUserStoryExists(UserStory story) => FindIfUserStoryExists(story, out UserStory temp);

        public bool FindIfUserStoryExists(UserStory story, out UserStory duplicate)
        {
            foreach (UserStoryContainer container in UserStoriesContainers)
            {
                duplicate = container.Stories.Find(x => x.Request == story.Request);
                if (duplicate != null) return true;
            }
            duplicate = null;
            return false;
        }

        [SerializeField]
        public List<UserStoryContainer> UserStoriesContainers;

        #region singleton 
        public static UserStoriesMain Instance
        {
            get
            {
                if (_instance == null) _instance = new UserStoriesMain();
                return _instance;
            }
            private set
            {
                _instance = new UserStoriesMain();
            }
        }

        private static UserStoriesMain _instance;
        #endregion
    }
}