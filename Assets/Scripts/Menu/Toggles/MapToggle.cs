using System;
using KarioMart.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KarioMart.Menu.Toggles
{
    public class MapToggle : DataToggle<MapData>
    {
        public override void Init(MapData data)
        {
            _data = data;
            titleLabel.text = _data.DisplayName;
            displayImage.sprite = _data.DisplayImage;
        }
    }
}
