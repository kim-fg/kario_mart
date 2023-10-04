using UnityEngine;

namespace KarioMart.Gamemodes.Data
{
    public class Lap
    {
        private float _lapStartTime;
        private float _lapEndTime;
        private bool _isActive;
        public float GetLapTime()
        {
            return _isActive ? Time.time - _lapStartTime : _lapEndTime - _lapStartTime;
        }

        public static Lap Max => new Lap {
            _lapStartTime = 0,
            _lapEndTime = float.MaxValue
        };

        public void Start()
        {
            _lapStartTime = Time.time;
            _isActive = true;
        }
        public void Stop()
        {
            _lapEndTime = Time.time;
            _isActive = false;
        }
            
        public bool IsRecord(Lap oldRecord) => oldRecord.GetLapTime() >= GetLapTime();
        
        public string LapTimeDisplayString()
        {
            var lapTime = GetLapTime();
            
            int minutes = (int) (lapTime / 60); // convert to minutes (probably never gonna happen)
            int seconds = (int) (lapTime % 60); // only count to 59, then start at 0
            int tenths = (int) (lapTime % 1 * 10); // convert decimal part to hundreds
            
            return $"{minutes}:{seconds:00}:{tenths}";
        }
        public static string EmptyLapTimeDisplayString() => "-:--:-";
    }
}