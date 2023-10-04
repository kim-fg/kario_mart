using KarioMart.Gamemodes.Data;
using KarioMart.UI;
using TMPro;
using UnityEngine;

namespace KarioMart
{
    public class TimeTrialGameOverScreen : ToggledUI
    {
        [SerializeField] private TextMeshProUGUI bestTimeLabel;
        [SerializeField] private GameObject newRecordIndicator;
        
        public void SetBestTime(Lap lap, bool isTrackRecord)
        {
            bestTimeLabel.text = $"Best Lap: {lap.LapTimeDisplayString()}";
            newRecordIndicator.SetActive(isTrackRecord);
        }
    }
}
