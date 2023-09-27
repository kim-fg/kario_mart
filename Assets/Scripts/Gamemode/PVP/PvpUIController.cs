using System;
using KarioMart.Util;
using UnityEngine;

namespace KarioMart.Gamemode.PVP
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
        }

        private void OnGameOver()
        {
            hud.SetActive(false);
            gameOverScreen.gameObject.SetActive(true);

            Time.timeScale = 0;
        }

        public void OnReturnToMenu()
        {
            Time.timeScale = 1;
            SceneLoader.Instance.LoadMainMenu();
        }
    }
}
