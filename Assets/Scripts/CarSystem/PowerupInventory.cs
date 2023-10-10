using System;
using System.Collections;
using KarioMart.Powerups;
using UnityEngine;

namespace KarioMart.CarSystem
{
    public class PowerupInventory : MonoBehaviour
    {
        public event Action<Powerup> OnGotPowerup;
        public event Action OnRemovedPowerup;
        
        private Car _car;
        private Powerup _currentPowerup;

        private void Awake()
        {
            _car = GetComponent<Car>();
        }

        public bool HasPowerup => _currentPowerup;
        
        public bool TrySetPowerup(Powerup powerup)
        {
            if (HasPowerup)
                return false;
            
            _currentPowerup = powerup;
            OnGotPowerup?.Invoke(_currentPowerup);
            return true;
        }

        private Coroutine _powerupRoutine;
        private bool PowerupActive => _powerupRoutine != null;

        public void UsePowerup()
        {
            if (!HasPowerup)
                return;
            
            if (PowerupActive)
                return;

            _currentPowerup.OnEffectEnd += OnEffectEnd;
            _powerupRoutine = StartCoroutine(_currentPowerup.Activate(_car));
        }

        private void OnEffectEnd(Car target)
        {
            if (!target.Equals(_car))
            {
                Debug.LogWarning("This is what you were protecting against!");
                return;
            }

            _currentPowerup.OnEffectEnd -= OnEffectEnd;
            _currentPowerup = null;
            _powerupRoutine = null;
            OnRemovedPowerup?.Invoke();
        }
    }
}
