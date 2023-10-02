using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace KarioMart.Gamemodes.TimeTrial
{
    [System.Serializable]
    public class TrackLeaderboard : JsonFile
    {
        public LapRecord[] LapRecords;
    }
    
    [System.Serializable]
    public class LapRecord : JsonFile
    {
        public float LapTime;
        public string PlayerName;
    }

    public class JsonFile
    {
        /// <summary>
        /// Save this class as a json file
        /// </summary>
        /// <param name="folder">Folder relative to persistentDataPath</param>
        /// <param name="filename">filename without extension</param>
        public void Save(string folder, string filename)
        {
            var jsonString = StringifySelf();
            var path = PersistentPath(folder, filename);
            WriteFile(path, jsonString);
        }

        private string StringifySelf()
        {
            return JsonUtility.ToJson(this, true);
        }

        private static string PersistentPath(string folder, string filename)
        {
            return $"{Application.persistentDataPath}{folder}{filename}.json";
        }

        /// <summary>
        /// Load a json class as a class
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="filename"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool TryLoad<T>(string folder, string filename, out T obj) where T: JsonFile
        {
            var path = PersistentPath(folder, filename);
            Debug.Log(path);
            if (!TryReadFile(path, out string jsonString))
            {
                obj = default;
                return false;
            }

            obj = JsonUtility.FromJson<T>(jsonString);
            return true;
        }
        
        private static void WriteFile(string path, string jsonString)
        {
            File.WriteAllText(path, jsonString);
        }

        private static bool TryReadFile(string path, out string jsonString)
        {
            jsonString = "";
            StreamReader streamReader = new StreamReader(path, Encoding.Default);
            string line;
            try
            {
                using (streamReader)
                {
                    do
                    {
                        line = streamReader.ReadLine();
                        if (line != null)
                            jsonString += line;

                    } while (line != null);

                    streamReader.Close();
                }

                return true;
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
    }
}
