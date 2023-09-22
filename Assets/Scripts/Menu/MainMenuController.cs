using KarioMart.Map;
using KarioMart.Util;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace KarioMart.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MapData[] maps;
        
        public void LoadSelectedMap()
        {
            SceneLoader.Instance.LoadMap(maps[0]);
        }
    }
}
