using UnityEngine;
using UnityEngine.InputSystem;

namespace KarioMart.Car
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float accelerationScale = 1f;
        [SerializeField] private float reverseScale = 0.5f;
        [SerializeField] private float steeringScale = 1f;
        [SerializeField] private float maxSpeed = 5f;

        private Rigidbody2D _rb2d;

        private float _steerInput;
        private float _speedInput;

        private void OnMove(InputValue inputValue)
        {
            var input = inputValue.Get<Vector2>();
            _steerInput = input.x;
            _speedInput = input.y;
        }

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var gasScale = _speedInput > 0 ? accelerationScale : reverseScale;

            var acceleration = (Vector2)transform.up * (_speedInput * gasScale * Time.deltaTime);
            var newVelocity = _rb2d.velocity + acceleration;
            var clampedSpeed = Mathf.Clamp(newVelocity.magnitude, float.Epsilon, maxSpeed);
            _rb2d.velocity = newVelocity.normalized * clampedSpeed;

            if (_rb2d.velocity.magnitude > float.Epsilon)
                transform.Rotate(-transform.forward, _steerInput * steeringScale);
        }
    }
}
