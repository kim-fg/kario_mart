using KarioMart.Gamemodes.Data;
using KarioMart.Map;
using KarioMart.Menu.Toggles;
using KarioMart.Util;
using UnityEngine;

namespace KarioMart.Menu.Submenus
{
    public class PlayMenu : SubMenu
    {
        // move from here
        [Header("Maps")]
        [SerializeField] private MapData[] maps;
        [SerializeField] private MapToggle mapTogglePrefab;
        [SerializeField] private Transform mapListTransform;
        
        [Header("Gamemodes")]
        [SerializeField] private GamemodeData[] gamemodes;
        [SerializeField] private GamemodeToggle gamemodeTogglePrefab;
        [SerializeField] private Transform gamemodeListTransform;
        // to here
        // into the display scripts
        // possibly excluding data
        
        [Header("Display")] 
        [SerializeField] private MapDisplay mapDisplay;

        private MapData _selectedMap;
        private GamemodeData _selectedGamemode;

        private void Start()
        {
            Clean();
            
            PopulateMapItems();
            PopulateGamemodeItems();
        }

        private void Clean()
        {
            for (int i = 0; i < mapListTransform.childCount; i++)
            {
                Destroy(mapListTransform.GetChild(i).gameObject);
            }
            
            for (int i = 0; i < gamemodeListTransform.childCount; i++)
            {
                Destroy(gamemodeListTransform.GetChild(i).gameObject);
            }
        }
        private void PopulateMapItems()
        {
            for (int i = 0; i < maps.Length; i++)
            {
                MapToggle mapToggle = Instantiate(mapTogglePrefab, mapListTransform);
                mapToggle.Init(maps[i]);
                mapToggle.OnDataChanged += SelectMap;
                mapToggle.enabled = true;
            }
        }

        private void PopulateGamemodeItems()
        {
            for (int i = 0; i < gamemodes.Length; i++)
            {
                GamemodeToggle gamemodeToggle = Instantiate(gamemodeTogglePrefab, gamemodeListTransform);
                gamemodeToggle.Init(gamemodes[i]);
                gamemodeToggle.OnDataChanged += SelectGamemode;
                gamemodeToggle.enabled = true;
            }
        }

        private void SelectMap(MapData mapData)
        {
            _selectedMap = mapData;
            mapDisplay.DisplayMap(mapData);
        }
        
        private void SelectGamemode(GamemodeData gamemode)
        {
            _selectedGamemode = gamemode;
        }
        
        public void StartGameSession() => GameManager.Instance.StartSession(_selectedMap, _selectedGamemode);
    }
}
