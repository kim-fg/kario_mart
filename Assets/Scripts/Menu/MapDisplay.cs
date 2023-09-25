using System.Collections;
using System.Collections.Generic;
using KarioMart.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KarioMart
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI mapTitleLabel;
        [SerializeField] private Image mapImage;
        [SerializeField] private TextMeshProUGUI mapDescriptionLabel;
        
        public void DisplayMap(MapData mapData)
        {
            mapTitleLabel.text = mapData.DisplayName;
            mapImage.sprite = mapData.DisplayImage;
            mapDescriptionLabel.text = mapData.Description;
        }
    }
}
