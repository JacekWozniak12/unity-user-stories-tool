using UnityEngine;

namespace UserStories
{
    /// <summary>
    /// Item built in manner: ask question, think why should be asked and how should we answer it.
    /// </summary>
    [CreateAssetMenu(menuName = Settings.MENU_SO_STORY)]
    public class UserStory : ScriptableObject
    {
        public UserStoryCategory Category;

        /// <summary>
        /// What user wants to do.
        /// </summary>
        public string Request;

        /// <summary>
        /// Why user wants that.
        /// </summary>
        public string WhyRequested;

        /// <summary>
        /// What should've been done to solve the issue risen by user.
        /// </summary>
        public string Answer;
    }
}