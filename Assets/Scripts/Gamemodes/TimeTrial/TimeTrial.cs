using System;
using System.Linq;
using KarioMart.CarSystem;
using KarioMart.Gamemodes.Data;
using KarioMart.Gamemodes.TimeTrial.Records;
using UnityEngine;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class TimeTrial : Gamemode
    {
        public event Action<Lap> OnSplit;
        public event Action<Lap> OnLapEnded;
        public event Action<Lap> OnNewBestLap;

        private int _currentCheckpointIndex;

        public int LapCount { get; private set; } = 1;
        public Lap CurrentLap { get; private set; }
        public bool RecordIsSet { get; private set; }
        public Lap BestLap { get; private set; }
        public TrackLeaderboard Leaderboard
        {
            get => MapManager.TrackLeaderboard;
            private set => MapManager.TrackLeaderboard = value;
        }

        protected override void Init()
        {
            MapManager.TogglePowerupBoxes(false);
            SpawnPlayerCar(MapManager.StartGridPositions[0], "KeyboardLeft");
            StartLap();
        }

        private void StartLap()
        {
            _currentCheckpointIndex = 0;
            CurrentLap = new Lap();
            CurrentLap.Start();
        }

        protected override void OnCarEnteredCheckpoint(Car car, Collider2D checkpoint)
        {
            var currentCheckpoint = MapManager.Checkpoints[_currentCheckpointIndex];
            if (!currentCheckpoint.Equals(checkpoint))
                return;
            
            _currentCheckpointIndex++;

            if (_currentCheckpointIndex.Equals(CheckpointCount))
            {
                EndLap();
                return;
            }
            
            OnSplit?.Invoke(CurrentLap);
        }

        private void EndLap()
        {
            CurrentLap.Stop();
            var newBestTime = BestLap == null || CurrentLap.IsRecord(BestLap);

            if (newBestTime)
            {
                BestLap = CurrentLap;
                RecordIsSet = true;
                OnNewBestLap?.Invoke(BestLap);
            }
            
            // save in highscore list
                // <--
            
            LapCount++;
            
            OnLapEnded?.Invoke(CurrentLap);
            
            StartLap();
        }

        public void SaveRecord(LapRecord lapRecord)
        {
            var oldLeaderBoard = Leaderboard;
            oldLeaderBoard.AddRecord(lapRecord);
            Leaderboard = oldLeaderBoard;
        }
    }
}
