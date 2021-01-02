using UnityEngine;

namespace UserStories
{
    /// <summary>
    /// Item built in manner: ask question, think why should be asked and how should we answer it.
    /// </summary>
    [CreateAssetMenu(menuName = Settings.MENU_SO_STORY)]
    public class UserStory : ScriptableObject
    {
        [Tooltip("Selected category of UserStory.")]
        public UserStoryCategory Category;

        /// <summary>
        /// What user wants to do.
        /// </summary>
        [TextArea]
        [Space]
        [Tooltip("What user wants to do.")]
        public string Request;

        /// <summary>
        /// Why user wants that.
        /// </summary>
        [TextArea]
        [Space]
        [Tooltip("Why user wants that.")]
        public string WhyRequested;

        /// <summary>
        /// What should've been done to solve the issue risen by user.
        /// </summary>
        [TextArea]
        [Space]
        [Tooltip("What should've been done to solve the issue risen by user.")]
        public string Answer;
    }
}