using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups.Spawnable.Components
{
    public class SpawnedPowerup : MonoBehaviour
    {
        [SerializeField] private bool destroyOnHit = true;
        [SerializeField] protected SpawnablePowerup data;

        private void Start()
        {
            Destroy(gameObject, data.ObjectLifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other) => OnHitObject(other.gameObject);
        private void OnCollisionEnter2D(Collision2D other) => OnHitObject(other.gameObject);

        private void OnHitObject(GameObject other)
        {
            if (!other.TryGetComponent(out Car car))
                return;

            StartCoroutine(data.OnHit(car));
            
            if (destroyOnHit)
                Destroy(gameObject);
        }
    }

    
}