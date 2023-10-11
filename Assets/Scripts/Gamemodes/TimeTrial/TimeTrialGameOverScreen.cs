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

        [Header("Leaderboard")] 
        [SerializeField] private Transform leaderboardList;
        [SerializeField] private LeaderboardItem leaderboardItemPrefab;

        private TimeTrial _timeTrial;
        
        private void Awake()
        {
            _timeTrial = transform.root.GetComponent<TimeTrial>();
        }

        public void OnNicknameEdited()
        {
            saveLapRecordButton.interactable = nicknameInputField.text.Length > 0;
        }
        
        public void DisplayLeaderboard()
        {
            var bestLap = _timeTrial.BestLap;
            var leaderboard = _timeTrial.Leaderboard;
            var trackRecordLap = leaderboard.GetBestRecord();
            if (bestLap == null)
            {
                bestTimeLabel.text = $"Zero laps completed..";
                nicknameInputField.interactable = false;
                saveLapRecordButton.interactable = false;
                newRecordIndicator.SetActive(false);
            }
            else
            {
                bestTimeLabel.text = $"Best Lap: {bestLap.LapTimeDisplayString()}";
                var isTrackRecord = trackRecordLap.IsDefault() || trackRecordLap.LapTime > bestLap.GetLapTime();
                newRecordIndicator.SetActive(isTrackRecord);
            }
            
            var lapRecords = leaderboard.LapRecords;
            if (lapRecords == null)
                return;
            
            for (int i = 0; i < lapRecords.Length; i++)
            {
                 var leaderBoardItem = Instantiate(leaderboardItemPrefab, leaderboardList);
                 leaderBoardItem.SetLapRecord(lapRecords[i], i);
            }
        }

        public void OnSaveRecord()
        {
            nicknameInputField.interactable = false;
            saveLapRecordButton.interactable = false;
            
            var lapRecord = new LapRecord(_timeTrial.BestLap.GetLapTime(), nicknameInputField.text);
            _timeTrial.SaveRecord(lapRecord);
        }
    }
}
