using System.Text;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

namespace UserStories
{
    public static class UserStoriesIO
    {
        /// <param name="list">List of UserStories to save</param>
        /// <param name="path">Directory where that list has to be saved</param>
        /// <returns>If save was succesful</returns>
        public static bool ExportContainerToJSON(List<UserStoryContainer> list, string path)
        {
            string data = JsonConvert.SerializeObject(list);

            try
            {
                File.WriteAllText(path, data, Encoding.UTF8);
            }
            catch (IOException e)
            {
                Debug.Log(e);
                return false;
            }

            return true;
        }

        public static List<UserStoryContainer> LoadContainerFromJSON(string path)
        {
            List<UserStoryContainer> container = null;

            try
            {
                string data = File.ReadAllText(path, Encoding.UTF8);
                container = JsonConvert.DeserializeObject<List<UserStoryContainer>>(data);
            }
            catch (IOException e)
            {
                Debug.Log(e);
                return null;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
            return container;
        }
    }
}