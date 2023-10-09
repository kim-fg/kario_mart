using KarioMart.Gamemodes;
using KarioMart.Gamemodes.Data;
using KarioMart.Map;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KarioMart.Util
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private bool loadMainMenuOnStart = true;
        [SerializeField] private string mainMenuSceneName;
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
            var asyncHandle = SceneManager.LoadSceneAsync(mapData.SceneName);
            asyncHandle.completed += delegate(AsyncOperation op)
            {
                var gamemodeManager = Instantiate(gamemodeManagerPrefab);
                gamemodeManager.Init(gamemodeData.Prefab);
            };
        }

        public void LoadMainMenu() => SceneManager.LoadSceneAsync(mainMenuSceneName);
    }
}
