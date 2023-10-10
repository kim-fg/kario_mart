using System.Collections;
using KarioMart.CarSystem;
using KarioMart.Powerups.Spawnable.Components;
using UnityEngine;

namespace KarioMart.Powerups.Spawnable
{
    [CreateAssetMenu(menuName = "Powerup/Spawnable/Oil Splat")]
    public class OilSplatPowerup : SpawnablePowerup
    {
        public override IEnumerator OnHit(Car target, SpawnedPowerup instance)
        {
            var prevAccel = target.AccelerationScale;
            target.AccelerationScale = 0;

            yield return EffectTimeWait;

            target.AccelerationScale = prevAccel;
            
            EndHitEffect(instance);
        }
    }
}