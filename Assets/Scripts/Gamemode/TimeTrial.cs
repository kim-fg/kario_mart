using System;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Gamemode
{
    public class TimeTrial : MonoBehaviour
    {
        public event Action<float> OnSplit;
        public event Action<Lap> OnLapEnded;
        
        [SerializeField] private Car car;
        [SerializeField] private Collider2D[] checkpointSequence;

        private int _currentCheckpointIndex;

        public int LapCount { get; private set; } = 1;
        public Lap CurrentLap { get; private set; }
        public Lap RecordLap { get; private set; } = Lap.Max;

        private void Awake()
        {
            car.OnEnterCheckpoint += CheckpointEntered;
            
            // load lap record if it exists
        }
        
        private void Start()
        {
            StartLap();
        }
        private void StartLap()
        {
            _currentCheckpointIndex = 0;
            CurrentLap = new Lap();
            CurrentLap.Start();
        }

        private void CheckpointEntered(Collider2D checkpoint)
        {
            var currentCheckpoint = checkpointSequence[_currentCheckpointIndex];
            if (!currentCheckpoint.Equals(checkpoint))
                return;
            
            _currentCheckpointIndex++;

            if (_currentCheckpointIndex.Equals(checkpointSequence.Length))
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
            }
            
            // save in highscore list
                // <--
            
            LapCount++;
            
            OnLapEnded?.Invoke(CurrentLap);
            
            
            StartLap();
        }
    }
}
