using System;
using KarioMart.Util;
using UnityEngine;

namespace KarioMart.CarSystem
{
    public class Car : MonoBehaviour
    {
        public event Action<Car, Collider2D> OnEnterCheckpoint;
        private static int _maxID = 0;
        
        [Header("Data")]
        [SerializeField] private float accelerationScale = 1f;
        [SerializeField] private float reverseScale = 0.5f;
        [SerializeField] private float steeringScale = 1f;
        [SerializeField] private float maxSpeed = 5f;

        [Header("Graphics")]
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Rigidbody2D _rb2d;
        private float _gas;
        private float _steering;
        private int _raceID;
        
        public float Speed => _rb2d.velocity.magnitude;
        public int RaceID => _raceID;
        public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

        public float AccelerationScale { get => accelerationScale; set => accelerationScale = value; }
        public Rigidbody2D Body => _rb2d;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _raceID = _maxID++;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                OnEnterCheckpoint?.Invoke(this, other);
            }
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        private void OnDestroy()
        {
            OnEnterCheckpoint = null;
            _maxID--;
        }
    }
}
