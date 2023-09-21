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
            var input = inputValue.Get<Vector2>();
            _car.ApplyGas(input.x);
            _car.ApplySteering(input.y);
        }
    }
}
