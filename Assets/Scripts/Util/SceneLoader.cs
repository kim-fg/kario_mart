using System;
using KarioMart.Map;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace KarioMart.Util
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }
        
        [SerializeField] private AssetReference mainMenu;
        
        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                mainMenu.LoadSceneAsync();
                return;
            }
            
            if (Instance != this)
                Destroy(this);
        }

        public void LoadMap(MapData mapData)
        {
            Addressables.LoadSceneAsync(mapData.Scene);
        }
    }
}
