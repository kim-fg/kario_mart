using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using KarioMart.CarSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace KarioMart
{
    public class TimeTrial : MonoBehaviour
    {
        [SerializeField] private Car car;
        [SerializeField] private Collider2D[] checkpointSequence;

        private int _currentCheckpointIndex;
        private float _lapStartTime;
        private float _lapEndTime;
        private float _bestLapTime;
        

        private void Awake()
        {
            _bestLapTime = float.MaxValue;
            
            car.OnEnterCheckpoint += CheckpointEntered;
        }
        
        private void Start()
        {
            StartLap();
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
        }

        private void StartLap()
        {
            _currentCheckpointIndex = 0;
            _lapStartTime = Time.time;
        }

        private void EndLap()
        {
            _lapEndTime = Time.time;

            var lapTime = LapTime();

            if (_bestLapTime > lapTime)
            {
                _bestLapTime = lapTime;
                //update ui here
                print($"New best time!");
            }
            
            // do ui stuff here
            print($"Lap time: {lapTime}");
            
            StartLap();
        }

        private float LapTime()
        {
            return _lapEndTime - _lapStartTime;
        }
    }
}
