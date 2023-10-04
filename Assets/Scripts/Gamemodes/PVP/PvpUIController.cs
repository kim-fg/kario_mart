using System;
using KarioMart.UI;
using KarioMart.Util;
using UnityEngine;
using UnityEngine.UIElements;

namespace KarioMart.Gamemodes.PVP
{
    public abstract class GamemodeUIController<T, U> : MonoBehaviour where T : Gamemode where U : ToggledUI 
    {
        [SerializeField] private GameObject hud;
        [SerializeField] protected U gameOverScreen;

        protected T _gamemode;
        
        private void OnEnable()
        {
            PauseMenu.OnPauseToggled += OnPauseToggled;
        }

        private void Awake()
        {
            _gamemode = transform.root.GetComponent<T>();
            _gamemode.OnGameOver += OnGameOver;
            
            gameOverScreen.Hide();
        }

        private void OnDisable()
        {
            PauseMenu.OnPauseToggled -= OnPauseToggled;
        }
        
        private void OnPauseToggled(bool paused)
        {
            hud.SetActive(!paused);
        }
        
        private void OnGameOver()
        {
            hud.SetActive(false);
            EndSession();
            gameOverScreen.Show();
            
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

        protected abstract void EndSession();
    }
    
    public class PvpUIController : GamemodeUIController<PvpGamemode, PvpGameOverScreen>
    {
        private PvpGamemode _pvpGamemode;

        protected override void EndSession()
        {
            var raceWinner = _pvpGamemode.GetLeadingCar();
            gameOverScreen.SetWinner(raceWinner);
        }
    }
}
