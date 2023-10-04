using System.Collections;
using KarioMart.Gamemodes.Data;
using TMPro;
using UnityEngine;

namespace KarioMart.Gamemodes.TimeTrial
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
            _timeTrial.OnSplit += delegate(Lap currentLap)
            {
                StartCoroutine(ShowSplitTime(currentLap));
            };
            _timeTrial.OnNewRecord += UpdateRecordLabel;
        }
        
        private void Start()
        {
            UpdateLapLabel();
            UpdateRecordLabel(_timeTrial.RecordLap);
            ToggleShowSplit();

            previousLapTimeLabel.text = $"Prev Lap: {Lap.EmptyLapTimeDisplayString()}";
            newRecordIndicator.SetActive(false);
        }

        private void FixedUpdate()
        {
            activeLapTimeLabel.text = _timeTrial.CurrentLap.LapTimeDisplayString();
        }
        
        private void UpdateRecordLabel(Lap lap)
        {
            var recordTimeString = _timeTrial.RecordIsSet ? 
                _timeTrial.RecordLap.LapTimeDisplayString() : Lap.EmptyLapTimeDisplayString();
            
            recordLapTimeLabel.text = $"Record: {recordTimeString}";

            // this should probably be moved to TimeTrial
            newRecordIndicator.SetActive(true);
        }

        
        private IEnumerator ShowSplitTime(Lap lap)
        {
            splitTimeLabel.text = $"Split: {lap.LapTimeDisplayString()}";
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
            previousLapTimeLabel.text = $"Prev Lap: {lap.LapTimeDisplayString()}";
        }
        
        private void UpdateLapLabel()
        {
            lapLabel.text = $"Lap: {_timeTrial.LapCount}";
        } 
    }
}
