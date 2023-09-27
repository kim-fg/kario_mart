using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarioMart.CarSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCarController : MonoBehaviour
    {
        private Car _car;

        private void Awake()
        {
            _car = GetComponent<Car>();
        }

        private void OnMove(InputValue inputValue)
        {
            print("tried move");
            
            var input = inputValue.Get<Vector2>();
            _car.ApplySteering(input.x);
            _car.ApplyGas(input.y);
        }
    }
}
