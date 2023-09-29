using System.Collections;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups.Applied
{
    [CreateAssetMenu(menuName = "Powerup/Applied/Turbo")]
    public class TurboPowerup : Powerup
    {
        [SerializeField] private float addedMaxSpeed = 3f;
        [SerializeField] private float addedAcceleration = 3f;

        public override IEnumerator Activate(Car target)
        {
            var prevSpeed = (target.MaxSpeed, target.AccelerationScale);
            target.MaxSpeed = prevSpeed.MaxSpeed + addedMaxSpeed;
            target.AccelerationScale = prevSpeed.AccelerationScale + addedAcceleration;
            
            yield return EffectTimeWait;
            
            target.MaxSpeed = prevSpeed.MaxSpeed;
            target.AccelerationScale = prevSpeed.AccelerationScale;
            
            EndEffect(target);
        }
    }
}