using System;
using KarioMart.Util;
using UnityEngine;

namespace KarioMart.Gamemodes.PVP
{
    public class PvpUIController : MonoBehaviour
    {
        [SerializeField] private GameObject hud;
        [SerializeField] private PvpGameOverScreen gameOverScreen;
        
        private PvpGamemode _pvpGamemode;
        private void Awake()
        {
            _pvpGamemode = transform.root.GetComponent<PvpGamemode>();
            _pvpGamemode.OnGameOver += OnGameOver;
            
            gameOverScreen.gameObject.SetActive(false);
            PauseMenu.OnPauseToggled += OnPauseToggled;
        }

        private void OnPauseToggled(bool paused)
        {
            hud.SetActive(!paused);
        }

        private void OnGameOver()
        {
            hud.SetActive(false);
            gameOverScreen.gameObject.SetActive(true);
            Time.timeScale = 0;

            //block pause menu
            if (!PauseMenu.IsBlocked)
                PauseMenu.ToggleBlocked(gameObject);
        }

        public void OnReturnToMenu()
        {
            Time.timeScale = 1;
            GameManager.Instance.LoadMainMenu();
            
            // unblock pause menu
            if (PauseMenu.IsBlocked)
                PauseMenu.ToggleBlocked(gameObject);
        }
    }
}
