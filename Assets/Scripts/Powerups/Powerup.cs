using System;
using System.Collections;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups
{
    public abstract class Powerup : ScriptableObject
    {
        public event Action<Car> OnEffectEnd;

        [SerializeField] private Sprite displaySprite;
        [Header("Data")]
        [SerializeField] protected float effectTime = 3f;

        public Sprite DisplaySprite => displaySprite;
        
        public abstract IEnumerator Activate(Car target);
        
        protected WaitForSeconds EffectTimeWait => new(effectTime);
        
        protected void EndActivation(Car target)
        {
            OnEffectEnd?.Invoke(target);
        }
    }
}
