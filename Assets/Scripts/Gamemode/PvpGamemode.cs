using System.Collections.Generic;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Gamemode
{
    public class PvpGamemode : Gamemode
    {
        [SerializeField] private Color playerOneColor = Color.blue;
        [SerializeField] private Color playerTwoColor = Color.red;
        
        private Dictionary<Car, RacePosition> _carRacePositions;

        protected override void Init()
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
                racePosition.EndLap();
            
            print($"{car} - {racePosition.PositionScore(CheckpointCount)}");
            
            _carRacePositions[car] = racePosition;
        }
    }

    struct RacePosition
    {
        public int CheckpointCounter;
        public int LapCounter;

        public int PositionScore(int lapValue) => LapCounter * lapValue + CheckpointCounter;

        public void EndLap()
        {
            CheckpointCounter = 0;
            LapCounter++;
        }
    }
}
