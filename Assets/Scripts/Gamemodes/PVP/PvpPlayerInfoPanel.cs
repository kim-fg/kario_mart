using System;
using KarioMart.CarSystem;
using TMPro;
using UnityEngine;

namespace KarioMart.Gamemodes.PVP
{
    public class PvpPlayerInfoPanel : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private int carID;

        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI playerLabel;
        [SerializeField] private TextMeshProUGUI lapLabel;
        [SerializeField] private TextMeshProUGUI checkpointLabel;
        
        
        private PvpGamemode _pvpGamemode;
        private Car _targetCar;

        private void Awake()
        {
            _pvpGamemode = transform.root.GetComponent<PvpGamemode>();
            _pvpGamemode.OnPlayerProgress += OnPlayerProgress;
        }

        private void Start()
        {
            playerLabel.text = $"Player {carID + 1}";
            UpdateLapLabel(0);
            UpdateCheckpointLabel(0);
        }

        private void OnPlayerProgress(Car car)
        {
            if(!carID.Equals(car.RaceID))
                return;
            
            var racePosition = _pvpGamemode.GetRacePosition(car);
            UpdateLapLabel(racePosition.LapCounter);
            UpdateCheckpointLabel(racePosition.CheckpointCounter);
        }

        private void UpdateLapLabel(int lap) => lapLabel.text = $"Lap: {lap + 1}/{_pvpGamemode.LapCount}";
        private void UpdateCheckpointLabel(int checkpoint) => checkpointLabel.text = $"CP: {checkpoint + 1}/{_pvpGamemode.CheckpointCount}";
    }
}
