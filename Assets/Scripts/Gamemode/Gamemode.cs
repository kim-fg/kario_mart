using System;
using KarioMart.CarSystem;
using KarioMart.Map;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarioMart.Gamemode
{
    public abstract class Gamemode : MonoBehaviour
    {
        public event Action OnGameOver;
        
        [SerializeField] private PlayerCarController playerPrefab;
        
        protected MapManager _mapManager;
        public int CheckpointCount => _mapManager.Checkpoints.Length;

        private void Start()
        {
            _mapManager = FindObjectOfType<MapManager>();
            Init();
        }

        protected abstract void Init();
        protected abstract void OnCarEnteredCheckpoint(Car car, Collider2D checkpoint);

        protected void GameOver() => OnGameOver?.Invoke();

        protected Car SpawnPlayerCar(Transform spawnTransform, string controlScheme)
        {
            var instance = PlayerInput.Instantiate(
                playerPrefab.gameObject, controlScheme: controlScheme, pairWithDevice: Keyboard.current
            );
            instance.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            var car = instance.GetComponent<Car>();
            car.OnEnterCheckpoint += OnCarEnteredCheckpoint;
            return car;
        }
    }
}