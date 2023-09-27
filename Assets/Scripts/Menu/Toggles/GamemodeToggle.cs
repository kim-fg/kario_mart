using System;
using KarioMart.Gamemodes.Data;
using UnityEngine;

namespace KarioMart.Menu.Toggles
{
    public class GamemodeToggle : DataToggle<GamemodeData>
    {
        public override void Init(GamemodeData data)
        {
            _data = data;
            titleLabel.text = _data.DisplayName;
            displayImage.sprite = _data.DisplayImage;
        }
    }
}
