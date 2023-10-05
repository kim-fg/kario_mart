using System;
using KarioMart.UI;
using KarioMart.Util;
using UnityEngine;
using UnityEngine.UIElements;

namespace KarioMart.Gamemodes.PVP
{
    public class PvpUIController : GamemodeUIController<PvpGamemode, PvpGameOverScreen>
    {
        private PvpGamemode _pvpGamemode;

        protected override void EndSession()
        {
            var raceWinner = _pvpGamemode.GetLeadingCar();
            gameOverScreen.SetWinner(raceWinner);
        }
    }
}
