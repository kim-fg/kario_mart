using System;
using System.Collections.Generic;
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

        public RacePosition GetRacePosition(Car car)
        {
            return _carRacePositions[car];
        }

        public override void Init()
        {
            _carRacePositions = new Dictionary<Car, RacePosition>();
            
            // I dont like working with strings, but this is imo the easiest way
            // to get the functionality that i want.
            // if i wanted more players, i would do it differently.
            var p1Car = SpawnPlayerCar(_mapManager.StartGridPositions[0], "KeyboardLeft");
            p1Car.SetColor(playerOneColor);
            _carRacePositions.Add(p1Car, new RacePosition());
            
            var p2Car = SpawnPlayerCar(_mapManager.StartGridPositions[1], "KeyboardRight");
            p2Car.SetColor(playerTwoColor);
            _carRacePositions.Add(p2Car, new RacePosition());
        }

        protected override void OnCarEnteredCheckpoint(Car car, Collider2D checkpoint)
        {
            var racePosition = _carRacePositions[car];
            var currentCheckpoint = _mapManager.Checkpoints[racePosition.CheckpointCounter];

            if (!checkpoint.Equals(currentCheckpoint))
                return;
            
            racePosition.CheckpointCounter++;

            if (racePosition.CheckpointCounter == CheckpointCount)
            {    
                racePosition.EndLap();
                
                if (racePosition.LapCounter == LapCount)
                {
                    print($"Game over! Player {car.RaceID + 1} wins :D");
                    GameOver();
                    return;
                }
            }
                
            
            //print($"{car} - {racePosition.PositionScore(CheckpointCount)}");
            
            _carRacePositions[car] = racePosition;
            
            
            
            OnPlayerProgress?.Invoke(car);
        }
    }
}
