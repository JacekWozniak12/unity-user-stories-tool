using UnityEditor;
using UnityEngine;

namespace UserStories
{
    /// <summary>
    /// Item built in manner: ask question, think why should be asked and how should we answer it.
    /// </summary>
    [System.Serializable]
    [CreateAssetMenu(menuName = Settings.MENU_SO_STORY)]
    public class UserStory : ScriptableObject
    {

        [Tooltip("Selected category of UserStory.")]
        public UserStoryCategory Category;

        /// <summary>
        /// What user wants to do.
        /// </summary>
        [TextArea(1, 5)]
        [Space]
        [Tooltip("What user wants to do.")]
        public string Request;

        /// <summary>
        /// Why user wants that.
        /// </summary>
        [TextArea(1, 10)]
        [Space]
        [Tooltip("Why user wants that.")]
        public string WhyRequested;

        /// <summary>
        /// What should've been done to solve the issue risen by user.
        /// </summary>
        [TextArea(1, 20)]
        [Space]
        [Tooltip("What should've been done to solve the issue risen by user.")]
        public string Answer;

        [ContextMenu("Clean white spaces")]
        public void TrimWhiteSpaces()
        {
#if UNITY_EDITOR
            Undo.RecordObject(this, "clean white spaces");
            EditorUtility.SetDirty(this);
#endif
            Answer = Answer.Trim();
            WhyRequested = WhyRequested.Trim();
            Request = Request.Trim();
        }
    }
}