using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarioMart.CarSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCarController : MonoBehaviour
    {
        private Car _car;
        private PowerupInventory _powerupInventory;

        private void Awake()
        {
            _car = GetComponent<Car>();
            _powerupInventory = GetComponent<PowerupInventory>();
        }

        private void OnMove(InputValue inputValue)
        {
            var input = inputValue.Get<Vector2>();
            _car.ApplySteering(input.x);
            _car.ApplyGas(input.y);
        }
        
        // input method
        private void OnUsePowerup()
        {
            _powerupInventory.UsePowerup();
        }
    }
}
