using UnityEngine;
using UnityEngine.Serialization;

namespace KarioMart.Gamemodes.Data
{
    [CreateAssetMenu(menuName = "Data/Gamemode")]
    public class GamemodeData : ScriptableObject
    {
        [SerializeField] private string displayName = "Gamemode";
        [SerializeField] private string description = "Gamemode description ...";
        [FormerlySerializedAs("gamemodePrefab")] [SerializeField] private Gamemode prefab;
        [SerializeField] private Sprite displayImage;
        
        public string DisplayName => displayName;
        public string Description => description;
        public Gamemode Prefab => prefab;
        public Sprite DisplayImage => displayImage;
    }
}
