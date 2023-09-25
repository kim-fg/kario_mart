using System;
using System.Collections;
using System.Collections.Generic;
using KarioMart.Map;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KarioMart
{
    public class MapItem : Selectable
    {
        public event Action<MapData> OnSelectedMap; 
        
        [Header("Display")]
        [SerializeField] private TextMeshProUGUI titleLabel;
        [SerializeField] private Image image;

        private MapData _mapData;
        
        public void Init(MapData mapData)
        {
            _mapData = mapData;
            titleLabel.text = _mapData.DisplayName;
            image.sprite = _mapData.DisplayImage;
        }

        public override void OnSelect(BaseEventData eventData)
        {
            OnSelectedMap?.Invoke(_mapData);
        }
    }
}
