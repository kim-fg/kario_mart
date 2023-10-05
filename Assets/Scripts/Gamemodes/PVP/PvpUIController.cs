using System;
using KarioMart.UI;
using KarioMart.Util;
using UnityEngine;
using UnityEngine.UIElements;

namespace KarioMart.Gamemodes.PVP
{
    public class PvpUIController : GamemodeUIController<PvpGamemode, PvpGameOverScreen>
    {
        protected override void EndSession()
        {
            var raceWinner = _gamemode.GetLeadingCar();
            gameOverScreen.SetWinner(raceWinner);
        }
    }
}
