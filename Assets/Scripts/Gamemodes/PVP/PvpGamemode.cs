using System;
using System.Collections.Generic;
using System.Linq;
using KarioMart.CarSystem;
using KarioMart.Gamemodes.Data;
using UnityEngine;

namespace KarioMart.Gamemodes.PVP
{
    public class PvpGamemode : Gamemode
    {
        public event Action<Car> OnPlayerProgress;
        
        [SerializeField] private int lapCount = 5;
        
        [Header("Player graphics")]
        [SerializeField] private Color playerOneColor = Color.blue;
        [SerializeField] private Color playerTwoColor = Color.red;
        
        private Dictionary<Car, RacePosition> _carRacePositions;
        
        public int LapCount => lapCount;

        public RacePosition GetRacePosition(Car car) => _carRacePositions[car];

        protected override void Init()
        {
            _carRacePositions = new Dictionary<Car, RacePosition>();
            
            // I dont like working with strings, but this is imo the easiest way
            // to get the functionality that i want.
            // if i wanted more players, i would do it differently.
            var p1Car = SpawnPlayerCar(MapManager.StartGridPositions[0], "KeyboardLeft");
            p1Car.SetColor(playerOneColor);
            _carRacePositions.Add(p1Car, new RacePosition());
            
            var p2Car = SpawnPlayerCar(MapManager.StartGridPositions[1], "KeyboardRight");
            p2Car.SetColor(playerTwoColor);
            _carRacePositions.Add(p2Car, new RacePosition());
        }

        protected override void StartLap()
        {
            // do nothing
        }

        protected override void OnCarEnteredCheckpoint(Car car, Collider2D checkpoint)
        {
            var racePosition = _carRacePositions[car];
            var currentCheckpoint = MapManager.Checkpoints[racePosition.CheckpointCounter];

            if (!checkpoint.Equals(currentCheckpoint))
                return;
            
            racePosition.CheckpointCounter++;

            if (racePosition.CheckpointCounter == CheckpointCount)
            {    
                racePosition.EndLap();
                
                if (racePosition.LapCounter == LapCount)
                {
                    GameOver();
                    return;
                }
            }
            
            _carRacePositions[car] = racePosition;
            OnPlayerProgress?.Invoke(car);
        }

        public Car GetLeadingCar()
        {
            var racePositionArray = _carRacePositions.ToArray();
            var sortedRacePositionArray = racePositionArray.OrderByDescending(pair => pair.Value.PositionScore(CheckpointCount));
            var firstPair = sortedRacePositionArray.First();
            return firstPair.Key;
        }
    }
}
