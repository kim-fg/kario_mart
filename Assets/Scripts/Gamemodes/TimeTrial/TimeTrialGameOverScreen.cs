using System;
using KarioMart.Gamemodes.Data;
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
        
        public void SetBestTime(Lap lap, bool isTrackRecord)
        {
            _bestLap = lap;
            
            bestTimeLabel.text = $"Best Lap: {lap.LapTimeDisplayString()}";
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
