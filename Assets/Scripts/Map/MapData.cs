using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
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
        [SerializeField] private AssetReference scene;

        public string DisplayName => displayName;
        public string Description => description;
        
        public AssetReference Scene => scene;
        public Sprite DisplayImage => displayImage;
    }
}