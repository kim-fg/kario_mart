using System;
using TMPro;
using UnityEngine;

namespace KarioMart.CarSystem
{
    public class CarHud : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI speedLabel;
        
        private Car _car;

        private void Awake()
        {
            _car = transform.root.GetComponent<Car>();
        }

        void FixedUpdate()
        {
            UpdateSpeedLabel();
        }

        private void UpdateSpeedLabel()
        {
            int deciUnitSpeed = (int)(_car.Speed * 10);
            speedLabel.text = $"{deciUnitSpeed} du/s";
        }
    }
}
