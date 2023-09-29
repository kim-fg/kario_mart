using System;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups.Spawnable.Components
{
    public class SpawnedPowerup : MonoBehaviour
    {
        [SerializeField] private bool destroyOnHit = true;
        [SerializeField] protected SpawnablePowerup data;

        private Car _spawner;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb.velocity = _spawner.transform.up * data.StartSpeed;
            print(_rb.velocity);
            Destroy(gameObject, data.ObjectLifeTime);
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

            StartCoroutine(data.OnHit(car));
            
            if (destroyOnHit)
                Destroy(gameObject);
        }
        
        public static SpawnedPowerup Instantiate(SpawnedPowerup original, Car spawner, Vector2 spawnPos)
        {
            var spawnedPowerup = Instantiate(original);
            spawnedPowerup._spawner = spawner;
            spawnedPowerup.transform.position = spawnPos; 

            return spawnedPowerup;
        }
    }    
}