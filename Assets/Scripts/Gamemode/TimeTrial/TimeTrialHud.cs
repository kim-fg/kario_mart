using System.Collections;
using KarioMart.Gamemode.Data;
using TMPro;
using UnityEngine;

namespace KarioMart.Gamemode.TimeTrial
{
    public class TimeTrialHud : MonoBehaviour
    {
        [SerializeField] private float showSplitDuration = 1f;
        
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI lapLabel;
        [SerializeField] private TextMeshProUGUI activeLapTimeLabel;
        [SerializeField] private TextMeshProUGUI splitTimeLabel;
        [SerializeField] private TextMeshProUGUI previousLapTimeLabel;

        [Header("Record")] 
        [SerializeField] private TextMeshProUGUI recordLapTimeLabel;
        [SerializeField] private GameObject newRecordIndicator;
        
        private TimeTrial _timeTrial;
        
        private void Awake()
        {
            _timeTrial = transform.root.GetComponent<TimeTrial>();
            _timeTrial.OnLapEnded += LapEnded;
            _timeTrial.OnSplit += delegate(float splitTime) { StartCoroutine(ShowSplitTime(splitTime)); };
            _timeTrial.OnNewRecord += UpdateRecordLabel;
        }
        
        private void Start()
        {
            UpdateLapLabel();
            UpdateRecordLabel(_timeTrial.RecordLap);
            ToggleShowSplit();

            previousLapTimeLabel.text = $"Prev Lap: {EmptyLapTimeDisplayString}";
            newRecordIndicator.SetActive(false);
        }

        private void FixedUpdate()
        {
            activeLapTimeLabel.text = LapTimeDisplayString(_timeTrial.CurrentLap.GetLapTime());
        }
        
        private void UpdateRecordLabel(Lap lap)
        {
            var recordTimeString = _timeTrial.RecordIsSet ? 
                LapTimeDisplayString(_timeTrial.RecordLap.GetLapTime()) : EmptyLapTimeDisplayString;
            
            recordLapTimeLabel.text = $"Record: {recordTimeString}";

            // this should probably be moved to TimeTrial
            newRecordIndicator.SetActive(true);
        }

        
        private IEnumerator ShowSplitTime(float splitTime)
        {
            splitTimeLabel.text = $"Split: {LapTimeDisplayString(splitTime)}";
            ToggleShowSplit();
            yield return new WaitForSeconds(showSplitDuration);
            ToggleShowSplit();
        }

        private void ToggleShowSplit()
        {
            splitTimeLabel.gameObject.SetActive(!splitTimeLabel.gameObject.activeSelf);
        }

        private void LapEnded(Lap lap)
        {
            UpdateLapLabel();
            previousLapTimeLabel.text = $"Prev Lap: {LapTimeDisplayString(lap.GetLapTime())}";
        }
        
        private void UpdateLapLabel()
        {
            lapLabel.text = $"Lap: {_timeTrial.LapCount}";
        }
        
        private string EmptyLapTimeDisplayString => "-:--:-"; 
        
        private string LapTimeDisplayString(float lapTime)
        {
            int minutes = (int) (lapTime / 60); // convert to minutes (probably never gonna happen)
            int seconds = (int) (lapTime % 60); // only count to 59, then start at 0
            int tenths = (int) (lapTime % 1 * 10); // convert decimal part to hundreds
            
            return $"{minutes}:{seconds:00}:{tenths}";
        } 
    }
}
