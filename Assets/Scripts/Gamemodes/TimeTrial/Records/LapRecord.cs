using KarioMart.Util;

namespace KarioMart.Gamemodes.TimeTrial.Records
{
    [System.Serializable]
    public struct LapRecord : IDefaultComparable
    {
        public float LapTime;
        public string PlayerName;

        public LapRecord(float lapTime, string playerName) => (LapTime, PlayerName) = (lapTime, playerName);

        public bool IsDefault() => Equals(default(LapRecord));
    }
}
