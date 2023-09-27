using System.Collections;
using System.Collections.Generic;
using KarioMart.Gamemodes;
using UnityEngine;
using UnityEngine.Serialization;

namespace KarioMart
{
    [CreateAssetMenu(menuName = "Data/Gamemode")]
    public class GamemodeData : ScriptableObject
    {
        [SerializeField] private string displayName = "Gamemode";
        [SerializeField] private string description = "Gamemode description ....";
        [SerializeField] private Gamemode gamemodePrefab;
        [SerializeField] private Sprite displayImage;
        
        public string DisplayName => displayName;
        public string Description => description;
        public Gamemode GamemodePrefab => gamemodePrefab;
        public Sprite DisplayImage => displayImage;
    }
}
