namespace UserStories.Library
{
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public static class Unity
    {
        public static T[] GetAssets<T>(string[] Paths) where T: UnityEngine.Object
        {
            string[] AssetsGUID = AssetDatabase.FindAssets($"t:{typeof(T).Name}", Paths);
            List<T> assets = new List<T>();

            foreach (string GUID in AssetsGUID)
            {
                string path = AssetDatabase.GUIDToAssetPath(GUID);
                T a = AssetDatabase.LoadAssetAtPath<T>(path);
                assets.Add(a);
            }
            return assets.ToArray();
        }

        
    }
}