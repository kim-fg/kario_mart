using KarioMart.Powerups;
using UnityEngine;

namespace KarioMart.CarSystem
{
    public class PowerupInventory : MonoBehaviour
    {
        private Car _car;
        private Powerup _currentPowerup;

        public bool HasPowerup => _currentPowerup;
        
        public bool TrySetPowerup(Powerup powerup)
        {
            if (HasPowerup)
                return false;

            _currentPowerup = powerup;
            return true;
        }

        public void UsePowerup()
        {
            if (!HasPowerup)
                return;
            
            _currentPowerup.Activate(_car);
            
        }
    }
}
