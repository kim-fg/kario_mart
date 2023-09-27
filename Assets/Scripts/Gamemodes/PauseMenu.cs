using System;
using KarioMart.Util;
using UnityEngine;

namespace KarioMart.Gamemodes
{
    public class PauseMenu : MonoBehaviour
    {
        public static event Action<bool> OnPauseToggled;
        
        [SerializeField] private GameObject content;

        private GamemodeManager _gamemodeManager;
        private bool _paused;

        private void Awake()
        {
            _gamemodeManager = transform.root.GetComponent<GamemodeManager>();
            
            content.SetActive(false);
        }

        //input method
        private void OnPause() => TogglePaused();
        
        public void Resume() => TogglePaused();

        public void EndSession()
        {
            TogglePaused();
            _gamemodeManager.ActiveGamemode.GameOver();
        }
        
        public void MainMenu() => GameManager.Instance.LoadMainMenu();

        private void TogglePaused()
        {
            _paused = !_paused;
            content.SetActive(_paused);
            Time.timeScale = _paused ? 0 : 1;
            
            OnPauseToggled?.Invoke(_paused);
        }

        private static GameObject _pauseBlocker;

        public static bool IsBlocked => _pauseBlocker;
        
        public static void ToggleBlocked(GameObject blocker)
        {
            if (_pauseBlocker)
            {
                if (_pauseBlocker.Equals(blocker))
                {
                    _pauseBlocker = null;
                    return;
                }
            }

            _pauseBlocker = blocker;
        }

        public static void ForceClearBlock() => _pauseBlocker = null;
    }
}
