using System;
using System.IO;
using KarioMart.Gamemodes.TimeTrial;
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

        private void Start()
        {
            LoadTrackLeaderboard();
        }

        public TrackLeaderboard TrackLeaderboard
        {
            get
            {
                if(_trackLeaderboard == null)
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
            print(TrackLeaderboardPath);
        }
        private void SaveTrackLeaderboard()
        {
            throw new System.NotImplementedException();
        }
    }
}
