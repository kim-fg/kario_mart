using System.Collections;
using KarioMart.CarSystem;
using KarioMart.Powerups.Spawnable.Components;
using UnityEngine;

namespace KarioMart.Powerups.Spawnable
{
    [CreateAssetMenu(menuName = "Powerup/Spawnable/Sawblade")]
    public class SawbladePowerup : SpawnablePowerup
    {
        public override IEnumerator OnHit(Car target, SpawnedPowerup instance)
        {
            var rb = target.Body;
            var prevDrag = (rb.drag, rb.angularDrag);
            rb.drag = 0;
            rb.angularDrag = 0;

            yield return EffectTimeWait;

            rb.drag = prevDrag.drag;
            rb.angularDrag = prevDrag.angularDrag;

            EndHitEffect(instance);
        }
    }
}
