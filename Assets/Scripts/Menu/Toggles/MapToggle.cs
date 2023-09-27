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
            Data = data;
            titleLabel.text = Data.DisplayName;
            displayImage.sprite = Data.DisplayImage;
        }
    }
}
