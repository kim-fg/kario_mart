using System;
using KarioMart.Gamemodes.Data;
using UnityEngine;

namespace KarioMart.Menu.Toggles
{
    public class GamemodeToggle : DataToggle<GamemodeData>
    {
        public override void Init(GamemodeData data)
        {
            Data = data;
            titleLabel.text = Data.DisplayName;
            displayImage.sprite = Data.DisplayImage;
        }
    }
}
