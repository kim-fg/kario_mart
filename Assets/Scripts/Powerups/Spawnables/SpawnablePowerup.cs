using System;
using KarioMart.CarSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace KarioMart.Powerups.Spawnables
{
    public abstract class SpawnablePowerup : MonoBehaviour
    {
        protected abstract void ApplyEffect(Car target);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Car car))
                ApplyEffect(car);
        }
    }
}