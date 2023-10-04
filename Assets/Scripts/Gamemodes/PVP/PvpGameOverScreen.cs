using KarioMart.CarSystem;
using KarioMart.UI;
using TMPro;
using UnityEngine;

namespace KarioMart.Gamemodes.PVP
{
    public class PvpGameOverScreen : ToggledUI
    {
        [SerializeField] private TextMeshProUGUI winnerLabel;
        
        public void SetWinner(Car winner)
        {
            winnerLabel.text = $"Player {winner.RaceID + 1} wins!";
        }
    }
}
