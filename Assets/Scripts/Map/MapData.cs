using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
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
        [SerializeField] private AssetReferenceT<SceneAsset> sceneAsset;
        [SerializeField] private AssetReferenceT<Sprite> displayImage;

        public string DisplayName => displayName;
        public string Description => description;
        public AssetReferenceT<SceneAsset> SceneAssetReference => sceneAsset;
        public AssetReferenceT<Sprite> DisplayImage => displayImage;

    }
}