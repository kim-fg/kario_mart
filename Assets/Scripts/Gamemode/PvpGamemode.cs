using System.Collections.Generic;
using KarioMart.CarSystem;
using KarioMart.Map;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarioMart.Gamemode
{
    public class PvpGamemode : MonoBehaviour
    {
        [SerializeField] private Color playerOneColor = Color.blue;
        [SerializeField] private Color playerTwoColor = Color.red;

        [SerializeField] private PlayerCarController playerPrefab;
        
        private MapManager _mapManager;
        private Dictionary<Car, RacePosition> _carRacePositions;
        
        public int CheckpointCount => _mapManager.Checkpoints.Length;
        
        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _mapManager = FindObjectOfType<MapManager>();
            _carRacePositions = new Dictionary<Car, RacePosition>();
            
            // I dont like working with strings, but this is imo the easiest way
            // to get the functionality that i want.
            // if i wanted more players, i would do it differently.
            var p1Car = SpawnPlayerCar(_mapManager.StartGridPositions[0], "KeyboardLeft");
            p1Car.SetColor(playerOneColor);
            p1Car.OnEnterCheckpoint += OnCarEnterCheckpoint;
            _carRacePositions.Add(p1Car, new RacePosition());
            
            var p2Car = SpawnPlayerCar(_mapManager.StartGridPositions[1], "KeyboardRight");
            p2Car.SetColor(playerTwoColor);
            p2Car.OnEnterCheckpoint += OnCarEnterCheckpoint;
            _carRacePositions.Add(p2Car, new RacePosition());
        }

        private void OnCarEnterCheckpoint(Car car, Collider2D checkpoint)
        {
            var racePosition = _carRacePositions[car];
            var currentCheckpoint = _mapManager.Checkpoints[racePosition.CheckpointCounter];

            if (checkpoint.Equals(currentCheckpoint))
                racePosition.CheckpointCounter++;

            if (racePosition.CheckpointCounter == CheckpointCount)
                racePosition.NewLap();
            
            print($"{car} - {racePosition.PositionScore(CheckpointCount)}");
            
            _carRacePositions[car] = racePosition;
        }

        private Car SpawnPlayerCar(Transform spawnTransform, string controlScheme)
        {
            var instance = PlayerInput.Instantiate(
                playerPrefab.gameObject, controlScheme: controlScheme, pairWithDevice: Keyboard.current
            );
            instance.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            return instance.GetComponent<Car>();
        }
    }

    struct RacePosition
    {
        public int CheckpointCounter;
        public int LapCounter;

        public int PositionScore(int lapValue) => LapCounter * lapValue + CheckpointCounter;

        public void NewLap()
        {
            CheckpointCounter = 0;
            LapCounter++;
        }
    }
}
