using System.Collections.Generic;
using UnityEngine;

namespace UserStories
{
    [System.Serializable]
    public class UserStoryContainer
    {
        public UserStoryCategory Category;

        public List<UserStory> Stories;
        public UserStoryContainer(UserStoryCategory category, List<UserStory> stories)
        {
            Category = category;
            Stories = stories;
        }

        /// <summary>
        /// Adds story to collection of the stories.
        /// </summary>
        /// <param name="forced">If we should dismiss story based on category or overwrite it to fit collection</param>
        /// <returns>If it was added succesfully</returns>
        public bool Add(UserStory story, bool forced = false)
        {
            if (story == null) return false;
            if (Category != story.Category)
            {
                if (!forced) return false;
                else story.Category = Category;
            }
            Stories.Add(story);
            return true;
        }

        public static List<UserStoryContainer> FindAllExistingContainers()
        {
            List<UserStoryContainer> containers = new List<UserStoryContainer>();
            
            return containers;
        }
    }

    public class UserStoryContainerViewer : UserStoryContainer
    {
        public UserStoryContainerViewer(UserStoryCategory category, List<UserStory> stories) : base(category, stories)
        {
        }

        public bool show;
    }
}