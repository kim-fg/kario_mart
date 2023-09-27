using KarioMart.Map;
using KarioMart.Menu.Toggles;
using KarioMart.Util;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace KarioMart.Menu.Submenus
{
    public class PlayMenu : SubMenu
    {
        [Header("Maps")]
        [SerializeField] private MapData[] maps;
        [FormerlySerializedAs("mapDataTogglePrefab")] [FormerlySerializedAs("mapItemPrefab")] [SerializeField] private MapToggle mapTogglePrefab;
        [SerializeField] private Transform mapListTransform;
        
        [Header("Display")] 
        [SerializeField] private MapDisplay mapDisplay;

        private ToggleGroup _toggleGroup;

        public MapData SelectedMap { get; private set; }

        private void Awake()
        {
            _toggleGroup = GetComponent<ToggleGroup>();
        }

        private void Start()
        {
            Clean();
            
            PopulateMapItems();
        }

        private void Clean()
        {
            for (int i = 0; i < mapListTransform.childCount; i++)
            {
                Destroy(mapListTransform.GetChild(i).gameObject);
            }
        }

        private void PopulateMapItems()
        {
            for (int i = 0; i < maps.Length; i++)
            {
                MapToggle mapToggle = Instantiate(mapTogglePrefab, mapListTransform);
                mapToggle.Init(maps[i]);
                mapToggle.OnDataChanged += SelectData;
                mapToggle.enabled = true;
            }
        }

        private void SelectData(MapData mapData)
        {
            SelectedMap = mapData;
            mapDisplay.DisplayMap(mapData);
        }
        
        public void LoadSelectedMap()
        {
            SceneLoader.Instance.LoadMap(SelectedMap);
        }
    }
}
