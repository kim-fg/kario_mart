using System;
using System.Collections;
using System.Collections.Generic;
using KarioMart.Map;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace KarioMart
{
    public class PlayMenu : MonoBehaviour
    {
        [Header("Maps")]
        [SerializeField] private MapData[] maps;
        [SerializeField] private MapItem mapItemPrefab;
        [SerializeField] private Transform mapListTransform;

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
                Destroy(mapListTransform.GetChild(0).gameObject);
            }
        }

        private void PopulateMapItems()
        {
            for (int i = 0; i < maps.Length; i++)
            {
                MapItem mapItem = Instantiate(mapItemPrefab, mapListTransform);
                mapItem.Init(maps[i]);
                mapItem.OnSelectedMap += DisplayMap;
            }
        }

        private void DisplayMap(MapData mapData)
        {
            SelectedMap = mapData;
        }
    }
}
