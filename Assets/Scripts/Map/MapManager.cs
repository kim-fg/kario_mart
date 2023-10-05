using System.IO;
using KarioMart.Gamemodes.TimeTrial.Records;
using KarioMart.Util;
using UnityEngine;

namespace KarioMart.Map
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private MapData mapData;
        [SerializeField] private Collider2D[] checkpoints;
        [SerializeField] private Transform[] startGridPositions;

        public Collider2D[] Checkpoints => checkpoints;
        public Transform[] StartGridPositions => startGridPositions;

        private TrackLeaderboard _trackLeaderboard;

        public TrackLeaderboard TrackLeaderboard
        {
            get
            {
                if(_trackLeaderboard.IsDefault())
                    LoadTrackLeaderboard();
                return _trackLeaderboard;
            }

            set
            {
                _trackLeaderboard = value;
                SaveTrackLeaderboard();
            }
        }

        private string TrackLeaderboardPath => PathBuilder.BuildJson(true, "leaderboards", mapData.DisplayName);

        private void LoadTrackLeaderboard()
        {
            try
            { 
                var reader = new StreamReader(TrackLeaderboardPath);
                var data = reader.ReadToEnd();
                _trackLeaderboard = JsonUtility.FromJson<TrackLeaderboard>(data);
                reader.Close();
            }
            catch (DirectoryNotFoundException)
            {
                CreateLeaderboardDirectory();
                SaveTrackLeaderboard();
            }
            catch (FileNotFoundException)
            {
                SaveTrackLeaderboard();
            }
        }

        private void SaveTrackLeaderboard()
        {
            try
            {
                var writer = new StreamWriter(TrackLeaderboardPath);
                var trackLeaderboardJson = JsonUtility.ToJson(_trackLeaderboard, true);
                writer.Write(trackLeaderboardJson);
                writer.Close();
            }
            catch (DirectoryNotFoundException)
            {
                CreateLeaderboardDirectory();
                SaveTrackLeaderboard();
            }
            catch (FileNotFoundException)
            {
                SaveTrackLeaderboard();
            }
        }
        
        private void CreateLeaderboardDirectory()
        {
            Directory.CreateDirectory(PathBuilder.Build(true, "leaderboards"));
        }
    }
}
