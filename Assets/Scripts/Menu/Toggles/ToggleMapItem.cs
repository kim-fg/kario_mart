using System;
using KarioMart.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KarioMart.Menu.Toggles
{
    public class ToggleMapItem : ToggleExt
    {
        public event Action<MapData> OnMapChanged;  
        
        [Header("Display")]
        [SerializeField] private TextMeshProUGUI titleLabel;
        [SerializeField] private Image displayImage;

        private MapData _mapData;

        private void Start()
        {
            Toggle.onValueChanged.AddListener(OnValueChanged);
        }

        public void Init(MapData mapData)
        {
            _mapData = mapData;
            titleLabel.text = _mapData.DisplayName;
            displayImage.sprite = _mapData.DisplayImage;
        }
        
        private void OnValueChanged(bool toggled)
        {
            SetColor(toggled);
            OnMapChanged?.Invoke(_mapData);
        }
    }
}
