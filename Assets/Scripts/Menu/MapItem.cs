using System;
using System.Collections;
using System.Collections.Generic;
using KarioMart.Map;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace KarioMart
{
    public class MapItem : Selectable
    {
        public event Action<MapData> OnSelectedMap; 
        
        [Header("Display")]
        [SerializeField] private TextMeshProUGUI titleLabel;
        [FormerlySerializedAs("image")] [SerializeField] private Image displayImage;

        private MapData _mapData;
        
        public void Init(MapData mapData)
        {
            _mapData = mapData;
            titleLabel.text = _mapData.DisplayName;
            displayImage.sprite = _mapData.DisplayImage;
        }

        public override void OnSelect(BaseEventData eventData)
        {
            OnSelectedMap?.Invoke(_mapData);
            base.OnSelect(eventData);
        }
    }
}