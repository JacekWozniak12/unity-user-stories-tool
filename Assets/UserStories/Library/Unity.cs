namespace UserStories.Library
{
    using System.Collections.Generic;
    using UnityEditor;
    public static class Unity
    {
        /// <summary>Return unfiltered list of objects of type T, gets from default path.</summary>
        /// <returns>Array of objects of type T where T is type of UnityEngine.Object</returns>
        public static List<T> GetAssets<T>() where T : UnityEngine.Object
        {
            List<T> assets = new List<T>();
            string[] AssetsGUID = AssetDatabase.FindAssets($"t:{typeof(T).Name}");

            foreach (string GUID in AssetsGUID)
            {
                string path = AssetDatabase.GUIDToAssetPath(GUID);
                T asset = AssetDatabase.LoadAssetAtPath<T>(path);
                if (asset != null) assets.Add(asset);
            }
            return assets;
        }

        /// <summary>Returns if operation was succesful and adds unfiltered list of objects of type T to referenced list from given path.</summary>
        /// <param name="assets">Existing list where found assets will be added</param>
        /// <returns>True if any asset was found in given directories and can be added to list</returns>
        public static bool GetAssets<T>(ref List<T> assets) where T : UnityEngine.Object
        {
            if (assets == null) return false;
            var part = GetAssets<T>();
            if (part.Count == 0) return false;
            assets.AddRange(part);
            return true;
        }

        /// <summary>Return unfiltered list of objects of type T from given paths.</summary>
        /// <param name="paths">Relative paths from project main catalog</param>
        /// <returns>Array of objects of type T where T is type of UnityEngine.Object</returns>
        public static List<T> GetAssets<T>(string[] paths) where T : UnityEngine.Object
        {
            List<T> assets = new List<T>();
            try
            {
                List<string> pathList = new List<string>(paths);
                pathList.ForEach(x => x.Trim());
                pathList = pathList.FindAll(x => x.Length > 0);

                string[] AssetsGUID = AssetDatabase.FindAssets($"t:{typeof(T).Name}", pathList.ToArray());

                foreach (string GUID in AssetsGUID)
                {
                    string path = AssetDatabase.GUIDToAssetPath(GUID);
                    T asset = AssetDatabase.LoadAssetAtPath<T>(path);
                    if (asset != null) assets.Add(asset);
                }
            }
            catch { }
            return assets;
        }

        /// <summary>Return unfiltered list of objects of type T from given path.</summary>
        /// <param name="paths">Relative path from project main catalog</param>
        /// <returns>Array of objects of type T where T is type of UnityEngine.Object</returns>
        public static List<T> GetAssets<T>(string path) where T : UnityEngine.Object => GetAssets<T>(new string[] { path });

        /// <summary> Returns if operation was succesful and adds unfiltered list of objects of type T to referenced list from given path.</summary>
        /// <param name="paths">Relative path from project main catalog<</param>
        /// <param name="assets">Existing list where found assets will be added</param>
        /// <returns>True if any asset was found in given directories and can be added to list</returns>
        public static bool GetAssets<T>(string[] paths, ref List<T> assets) where T : UnityEngine.Object
        {
            if (assets == null) return false;
            var part = GetAssets<T>(paths);
            if (part.Count == 0) return false;
            assets.AddRange(part);
            return true;
        }

        /// <summary>Returns if operation was succesful  and adds unfiltered list of objects of type T to referenced list from given path.</summary>
        /// <param name="paths">Relative path from project main catalog<</param>
        /// <param name="assets">Existing list where found assets will be added</param>
        /// <returns>True if any asset was found in given directories and can be added to list</returns>
        public static bool GetAssets<T>(string path, ref List<T> assets) where T : UnityEngine.Object => GetAssets<T>(path, ref assets);
    }
}


