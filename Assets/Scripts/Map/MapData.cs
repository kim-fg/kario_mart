using UnityEngine;
using UnityEngine.Serialization;

namespace KarioMart.Map
{
    [CreateAssetMenu(menuName = "Data/Map")]
    public class MapData : ScriptableObject
    {
        [Header("Text")]
        [SerializeField] private string displayName = "Map Display Name";
        [Multiline(5)]
        [SerializeField] private string description;
        
        [Header("Assets")]
        [SerializeField] private Sprite displayImage;
        [FormerlySerializedAs("scene")] [SerializeField] private string sceneName;

        public string DisplayName => displayName;
        public string Description => description;
        
        public string SceneName => sceneName;
        public Sprite DisplayImage => displayImage;
    }
}