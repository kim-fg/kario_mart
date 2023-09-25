using System;
using System.Collections;
using System.Collections.Generic;
using KarioMart.Map;
using KarioMart.Menu;
using KarioMart.Util;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace KarioMart
{
    public class PlayMenu : SubMenu
    {
        [Header("Maps")]
        [SerializeField] private MapData[] maps;
        [SerializeField] private MapItem mapItemPrefab;
        [SerializeField] private Transform mapListTransform;
        
        [Header("Display")] 
        [SerializeField] private MapDisplay mapDisplay;

        public MapData SelectedMap { get; private set; }
        
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
                MapItem mapItem = Instantiate(mapItemPrefab, mapListTransform);
                mapItem.Init(maps[i]);
                mapItem.OnSelectedMap += SelectMap;
            }
        }

        private void SelectMap(MapData mapData)
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
