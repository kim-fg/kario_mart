using System;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups.Spawnable.Components
{
    public class SpawnedPowerup : MonoBehaviour
    {
        [SerializeField] protected SpawnablePowerup data;

        private Car _spawner;
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;
        private float _spawnTime;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            _rb.velocity = _spawner.transform.up * data.StartSpeed;
            _spawnTime = Time.time;
        }

        private void FixedUpdate()
        {
            if (Time.time - _spawnTime > data.ObjectLifeTime)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other) => OnHitObject(other.gameObject);
        private void OnCollisionEnter2D(Collision2D other) => OnHitObject(other.gameObject);

        private void OnHitObject(GameObject other)
        {
            if (!other.TryGetComponent(out Car car))
                return;
            
            // this solution isnt very fair..
            // would be better if it would ignore collision with
            // cars for a bit after spawn instead
            if (car.Equals(_spawner))
                return;

            DisableSelf();
            StartCoroutine(data.OnHit(car, this));
        }

        public static SpawnedPowerup Instantiate(SpawnedPowerup original, Car spawner, Vector2 spawnPos)
        {
            var spawnedPowerup = Instantiate(original);
            spawnedPowerup._spawner = spawner;
            spawnedPowerup.transform.position = spawnPos; 

            return spawnedPowerup;
        }
        
        private void DisableSelf()
        {
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
            _rb.isKinematic = true;
            enabled = false;
        }
    }    
}