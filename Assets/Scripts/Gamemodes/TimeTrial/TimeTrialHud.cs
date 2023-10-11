using System.Collections;
using KarioMart.Gamemodes.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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

        [Header("Best Lap UI")] 
        [FormerlySerializedAs("recordLapTimeLabel")]
        [SerializeField] private TextMeshProUGUI bestLapTimeLabel;
        [FormerlySerializedAs("newRecordIndicator")] 
        [SerializeField] private GameObject newBestLapIndicator;
        
        private TimeTrial _timeTrial;
        
        private void Awake()
        {
            _timeTrial = transform.root.GetComponent<TimeTrial>();
            _timeTrial.OnLapEnded += LapEnded;
            _timeTrial.OnSplit += delegate(Lap currentLap) { StartCoroutine(ShowSplitTime(currentLap)); };
            _timeTrial.OnNewBestLap += UpdateBestLapLabel;
        }
        
        private void Start()
        {
            UpdateLapLabel();
            UpdateBestLapLabel(_timeTrial.BestLap);
            ToggleShowSplit();

            previousLapTimeLabel.text = $"Prev Lap: {Lap.EmptyLapTimeDisplayString()}";
            newBestLapIndicator.SetActive(false);
        }

        private void FixedUpdate()
        {
            activeLapTimeLabel.text = _timeTrial.CurrentLap?.LapTimeDisplayString();
        }
        
        private void UpdateBestLapLabel(Lap lap)
        {
            var recordTimeString = _timeTrial.RecordIsSet ? 
                _timeTrial.BestLap.LapTimeDisplayString() : Lap.EmptyLapTimeDisplayString();
            
            bestLapTimeLabel.text = $"Record: {recordTimeString}";

            // this should probably be moved to TimeTrial
            newBestLapIndicator.SetActive(true);
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
