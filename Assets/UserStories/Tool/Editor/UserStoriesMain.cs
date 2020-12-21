namespace UserStories
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Main object to handle User Story App. Access by using Instance property.
    /// </summary>
    public class UserStoriesMain
    {
        private UserStoriesMain()
        {
            UserStoriesContainers = new List<UserStoryContainer>();
        }

        public void FindAllUserStories()
        {

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
            if(!FindIfUserStoryExists(story)) container.Add(story);
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