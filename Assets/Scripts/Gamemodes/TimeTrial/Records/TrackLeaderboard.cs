using System.Linq;
using KarioMart.Gamemodes.Data;

namespace KarioMart.Gamemodes.TimeTrial.Records
{
    [System.Serializable]
    public struct TrackLeaderboard : IDefaultComparable
    {
        public LapRecord[] LapRecords;
        
        public TrackLeaderboard(LapRecord[] lapRecords)
        {
            LapRecords = lapRecords.OrderByDescending(l => l.LapTime).ToArray();
        }

        public bool IsDefault()
        {
            return Equals(default(TrackLeaderboard));
        }

        public LapRecord GetBestRecord()
        {
            if (LapRecords == null)
                return default;
            
            return LapRecords.Length > 0 ? LapRecords[0] : default;
        }
    }
}