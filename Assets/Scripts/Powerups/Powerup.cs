using System;
using System.Collections;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups
{
    public abstract class Powerup : ScriptableObject
    {
        public event Action<Car> OnEffectEnd;
        
        [Header("Data")]
        [SerializeField] protected float effectTime = 3f;
        
        public abstract IEnumerator Activate(Car target);
        
        protected WaitForSeconds EffectTimeWait => new(effectTime);

        protected void EndEffect(Car target) => OnEffectEnd?.Invoke(target);
    }
}
