using System;
using KarioMart.CarSystem;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace KarioMart.Powerups
{
    public class PowerupBox : MonoBehaviour
    {
        [SerializeField, Min(0)] private float hideTime = 1f;
        [SerializeField] private Powerup[] powerups;

        private bool _active = true;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;


        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PowerupInventory powerupInventory))
            {
                var powerup = GetRandomPowerup();
                var setPowerup = powerupInventory.TrySetPowerup(powerup);

                if (setPowerup)
                    ToggleActive();
            }
        }

        private Powerup GetRandomPowerup() => powerups[Random.Range(0, powerups.Length)];
        
        private void ToggleActive()
        {
            _active = !_active;
            _spriteRenderer.enabled = _active;
            _collider.enabled = _active;
            if (!_active)
                Invoke(nameof(ToggleActive), hideTime);
        }
    }
}