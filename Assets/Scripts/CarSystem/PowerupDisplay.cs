using KarioMart.Powerups;
using UnityEngine;

namespace KarioMart.CarSystem
{
    public class PowerupDisplay : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private PowerupInventory _powerupInventory;
        
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            _powerupInventory = transform.root.GetComponent<PowerupInventory>();
            _powerupInventory.OnGotPowerup += DisplayPowerup;
            _powerupInventory.OnRemovedPowerup += HidePowerup;
        }

        private void DisplayPowerup(Powerup powerup)
        {
            _spriteRenderer.sprite = powerup.DisplaySprite;
            _spriteRenderer.enabled = true;
        }
        
        private void HidePowerup()
        {
            _spriteRenderer.sprite = null;
            _spriteRenderer.enabled = false;
        }
    }
}
