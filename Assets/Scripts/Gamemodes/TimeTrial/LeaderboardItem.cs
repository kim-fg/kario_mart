using KarioMart.Gamemodes.Data;
using KarioMart.Gamemodes.TimeTrial.Records;
using TMPro;
using UnityEngine;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class LeaderboardItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        public void SetLapRecord(LapRecord lapRecord, int index)
        {
            label.text = $"{index + 1}: {lapRecord.PlayerName} - {Lap.LapTimeDisplayString(lapRecord.LapTime)}";
        }
    }
}