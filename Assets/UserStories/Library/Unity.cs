namespace UserStories.Library
{
    using System.Collections.Generic;
    using UnityEditor;
    public static class Unity
    {
        /// <summary>
        /// Return unfiltered list of objects of type T from given paths.
        /// </summary>
        /// <param name="paths">Relative paths from project main catalog</param>
        /// <returns>Array of objects of type T where T is type of UnityEngine.Object</returns>
        public static T[] GetAssets<T>(string[] paths) where T : UnityEngine.Object
        {
            string[] AssetsGUID = AssetDatabase.FindAssets($"t:{typeof(T).Name}", paths);
            List<T> assets = new List<T>();

            foreach (string GUID in AssetsGUID)
            {
                string path = AssetDatabase.GUIDToAssetPath(GUID);
                T a = AssetDatabase.LoadAssetAtPath<T>(path);
                assets.Add(a);
            }
            return assets.ToArray();
        }

        /// <summary>
        /// Return unfiltered list of objects of type T from given path.
        /// </summary>
        /// <param name="paths">Relative path from project main catalog</param>
        /// <returns>Array of objects of type T where T is type of UnityEngine.Object</returns>
        public static T[] GetAssets<T>(string path) where T : UnityEngine.Object => GetAssets<T>(new string[] { path });
    }
}


