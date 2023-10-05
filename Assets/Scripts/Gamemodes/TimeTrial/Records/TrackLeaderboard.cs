using System.Linq;
using KarioMart.Gamemodes.Data;

namespace KarioMart.Gamemodes.TimeTrial.Records
{
    [System.Serializable]
    public struct TrackLeaderboard : IDefaultComparable
    {
        // I should probably use List for this, but I'm lazy.
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

        public void AddRecord(LapRecord lapRecord)
        {
            LapRecords = LapRecords.Concat(new [] { lapRecord }).ToArray();
        }
    }
}