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
        
        [FormerlySerializedAs("sceneAsset")]
        [Header("Assets")]
        [SerializeField] private AssetReference scene;
        [SerializeField] private AssetReference displayImage;

        public string DisplayName => displayName;
        public string Description => description;
        
        public AssetReference Scene => scene;
        public AssetReference DisplayImage => displayImage;
    }
}