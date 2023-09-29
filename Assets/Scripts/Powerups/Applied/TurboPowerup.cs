using System.Collections;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups.Applied
{
    [CreateAssetMenu(menuName = "Powerup/Applied/Turbo")]
    public class TurboPowerup : Powerup
    {
        [SerializeField] private float addedMaxSpeed = 3f;

        public override IEnumerator Activate(Car target)
        {
            var prevMaxSpeed = target.MaxSpeed;
            target.MaxSpeed = prevMaxSpeed + addedMaxSpeed;
            yield return EffectTimeWait;
            target.MaxSpeed = prevMaxSpeed;
        }
    }
}