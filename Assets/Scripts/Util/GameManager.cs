using System;
using KarioMart.Gamemodes;
using KarioMart.Gamemodes.Data;
using KarioMart.Map;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Object = UnityEngine.Object;

namespace KarioMart.Util
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private bool loadMainMenuOnStart = true;
        [SerializeField] private AssetReference mainMenu;
        [SerializeField] private GamemodeManager gamemodeManagerPrefab;

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
                
                if (loadMainMenuOnStart)
                    LoadMainMenu();
                return;
            }
            
            if (Instance != this)
                Destroy(this);
        }

        public void StartSession(MapData mapData, GamemodeData gamemodeData)
        {
            var asyncHandle = Addressables.LoadSceneAsync(mapData.Scene);
            asyncHandle.Completed += delegate(AsyncOperationHandle<SceneInstance> handle)
            {
                var gamemodeManager = Instantiate(gamemodeManagerPrefab);
                gamemodeManager.Init(gamemodeData.Prefab);
            };
        }

        public void LoadMainMenu() => mainMenu.LoadSceneAsync();
    }
}
