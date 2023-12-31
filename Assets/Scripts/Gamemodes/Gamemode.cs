using System;
using KarioMart.CarSystem;
using KarioMart.Map;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarioMart.Gamemodes
{
    public abstract class Gamemode : MonoBehaviour
    {
        private event Action OnBeginRace;
        public event Action OnGameOver;
        
        [SerializeField] private PlayerCarController playerPrefab;
        
        protected MapManager MapManager;
        
        public int CheckpointCount => MapManager.Checkpoints.Length;

        private void Start()
        {
            MapManager = FindObjectOfType<MapManager>();
            Init();
        }

        public void BeginRace()
        {
            OnBeginRace?.Invoke();
            OnBeginRace = null;
            
            StartLap();
        }

        protected abstract void Init();
        protected abstract void StartLap();
        protected abstract void OnCarEnteredCheckpoint(Car car, Collider2D checkpoint);

        public void GameOver() => OnGameOver?.Invoke();

        protected Car SpawnPlayerCar(Transform spawnTransform, string controlScheme)
        {
            var instance = PlayerInput.Instantiate(
                playerPrefab.gameObject, controlScheme: controlScheme, pairWithDevice: Keyboard.current
            );
            instance.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            var car = instance.GetComponent<Car>();
            car.OnEnterCheckpoint += OnCarEnteredCheckpoint;
            OnBeginRace += delegate
            {
                car.enabled = true;
            };
            car.enabled = false;
            return car;
        }
    }
}