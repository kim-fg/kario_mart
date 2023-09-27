using System;
using KarioMart.CarSystem;
using KarioMart.Gamemodes.Data;
using UnityEngine;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class TimeTrial : Gamemode
    {
        public event Action<float> OnSplit;
        public event Action<Lap> OnLapEnded;
        public event Action<Lap> OnNewRecord;

        private int _currentCheckpointIndex;

        public int LapCount { get; private set; } = 1;
        public Lap CurrentLap { get; private set; }
        public Lap RecordLap { get; private set; } = Lap.Max;
        public bool RecordIsSet { get; private set; }

        protected override void Init()
        {
            SpawnPlayerCar(_mapManager.StartGridPositions[0], "Keyboard&Mouse");
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
            var currentCheckpoint = _mapManager.Checkpoints[_currentCheckpointIndex];
            if (!currentCheckpoint.Equals(checkpoint))
                return;
            
            _currentCheckpointIndex++;

            if (_currentCheckpointIndex.Equals(CheckpointCount))
            {
                EndLap();
                return;
            }
            
            OnSplit?.Invoke(CurrentLap.GetLapTime());
        }

        private void EndLap()
        {
            CurrentLap.Stop();
            var newBestTime = CurrentLap.IsRecord(RecordLap);

            if (newBestTime)
            {
                RecordLap = CurrentLap;
                RecordIsSet = true;
                OnNewRecord?.Invoke(RecordLap);
            }
            
            // save in highscore list
                // <--
            
            LapCount++;
            
            OnLapEnded?.Invoke(CurrentLap);
            
            StartLap();
        }
    }
}
