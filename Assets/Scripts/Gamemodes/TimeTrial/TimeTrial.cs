using System;
using KarioMart.CarSystem;
using KarioMart.Gamemodes.Data;
using UnityEngine;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class TimeTrial : Gamemode
    {
        public event Action<Lap> OnSplit;
        public event Action<Lap> OnLapEnded;
        public event Action<Lap> OnNewRecord;

        private int _currentCheckpointIndex;

        public int LapCount { get; private set; } = 1;
        public Lap CurrentLap { get; private set; }
        public Lap BestLap { get; private set; } = Lap.Max;
        public bool RecordIsSet { get; private set; }

        public Lap TrackRecord()
        {
            // this is wrong for now
            // should send the fastest lap on the current track
            return Lap.Max;
        } 

        protected override void Init()
        {
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
            var newBestTime = CurrentLap.IsRecord(BestLap);

            if (newBestTime)
            {
                BestLap = CurrentLap;
                RecordIsSet = true;
                OnNewRecord?.Invoke(BestLap);
            }
            
            // save in highscore list
                // <--
            
            LapCount++;
            
            OnLapEnded?.Invoke(CurrentLap);
            
            StartLap();
        }
    }
}
