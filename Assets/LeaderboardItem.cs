using System.Collections;
using System.Collections.Generic;
using KarioMart.Gamemodes.Data;
using KarioMart.Gamemodes.TimeTrial.Records;
using TMPro;
using UnityEngine;

namespace KarioMart
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