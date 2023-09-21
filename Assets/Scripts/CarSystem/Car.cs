using KarioMart.Util;
using UnityEngine;

namespace KarioMart.CarSystem
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float accelerationScale = 1f;
        [SerializeField] private float reverseScale = 0.5f;
        [SerializeField] private float steeringScale = 1f;
        [SerializeField] private float maxSpeed = 5f;

        private Rigidbody2D _rb2d;
        private float _gas;
        private float _steering;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        public void ApplyGas(float gas) => _gas = Maths.ClampNeg1Pos1(gas);
        public void ApplySteering(float steering) => _steering = Maths.ClampNeg1Pos1(steering);
        private void FixedUpdate()
        {
            var gasScale = _gas > 0 ? accelerationScale : reverseScale;
            var deltaGas =  _gas * gasScale * Time.deltaTime;
            var acceleration = (Vector2)transform.up * deltaGas;
            var newVelocity = _rb2d.velocity + acceleration;
            var clampedSpeed = Mathf.Clamp(newVelocity.magnitude, float.Epsilon, maxSpeed);
            _rb2d.velocity = newVelocity.normalized * clampedSpeed;

            if (_rb2d.velocity.magnitude > float.Epsilon)
                transform.Rotate(-transform.forward, _steering * steeringScale);
        }
    }
}
