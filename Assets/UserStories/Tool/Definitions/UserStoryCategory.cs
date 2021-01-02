namespace UserStories
{
    using System;
    using UnityEngine;

    [System.Serializable]
    [CreateAssetMenu(menuName = Settings.MENU_SO_CATEGORY)]
    public class UserStoryCategory : ScriptableObject, IEquatable<UserStoryCategory>
    {
        public string Name;

        [Space]
        [TextArea]
        public string Description;

        [Space]
        [ColorUsage(true, true)]
        public Color TextColor;

        public bool Equals(UserStoryCategory other)
        {
            if (this.Name != other.Name) return false;
            if (this.Description != other.Description) return false;
            if (this.TextColor != other.TextColor) return false;
            return true;
        }
    }
}