using System;
using KarioMart.Gamemodes.Data;
using KarioMart.Gamemodes.TimeTrial.Records;
using KarioMart.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class TimeTrialGameOverScreen : ToggledUI
    {
        [SerializeField] private TextMeshProUGUI bestTimeLabel;
        [SerializeField] private GameObject newRecordIndicator;
        [SerializeField] private TMP_InputField nicknameInputField;
        [SerializeField] private Button saveLapRecordButton;
        
        private Lap _bestLap;

        public void OnNicknameEdited()
        {
            saveLapRecordButton.interactable = nicknameInputField.text.Length > 0;
        }
        
        public void DisplayLeaderboard(Lap bestLap, TrackLeaderboard trackLeaderboard)
        {
            _bestLap = bestLap;
            double trackRecordTime = trackLeaderboard.GetBestRecord().LapTime;
            bool isTrackRecord = trackRecordTime > _bestLap.GetLapTime();
            
            bestTimeLabel.text = $"Best Lap: {bestLap.LapTimeDisplayString()}";
            newRecordIndicator.SetActive(isTrackRecord);
        }

        public void OnSaveRecord()
        {
            nicknameInputField.interactable = false;
            saveLapRecordButton.interactable = false;
            // save _bestlap as json
            
            
        }
    }
}
