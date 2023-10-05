using System.Text;
using UnityEngine;

namespace KarioMart.Util
{
    public static class PathBuilder
    {
        public static string Build(bool fromPersistentDataPath, params object[] pathSegments)
        {
            var stringBuilder = new StringBuilder();
            if (fromPersistentDataPath)
                stringBuilder.Append(Application.persistentDataPath + "/");
            
            for (int i = 0; i < pathSegments.Length; i++)
            {
                stringBuilder.Append(pathSegments[i]);
                if (i < pathSegments.Length - 1)
                    stringBuilder.Append('/');
            }

            return stringBuilder.ToString();
        }

        public static string BuildJson(bool fromPersistentDataPath, params object[] pathSegments)
        {
            var path = Build(fromPersistentDataPath, pathSegments);
            path += ".json";
            return path;
        }
    }
}