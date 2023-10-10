using System;
using System.Collections;
using KarioMart.CarSystem;
using KarioMart.Powerups.Spawnable.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace KarioMart.Powerups.Spawnable
{
    public abstract class SpawnablePowerup : Powerup
    {
        [SerializeField] private float objectLifeTime = 3f;
        [SerializeField] private float startSpeed = 5f;
        
        [Header("Spawning")]
        [SerializeField] private bool spawnBehind;
        [SerializeField] private SpawnedPowerup spawnedPowerupPrefab;
        
        public float ObjectLifeTime => objectLifeTime;
        public float StartSpeed => startSpeed;

        public override IEnumerator Activate(Car target)
        {
            var spawnDirection = spawnBehind ? -1 : 1;
            var spawnPos = target.transform.position + target.transform.up * (2 * spawnDirection);
            var spawnable = SpawnedPowerup.Instantiate(spawnedPowerupPrefab, target, spawnPos);
            spawnable.transform.position = spawnPos;
            
            yield return null;
            
            EndActivation(target);
        }

        public abstract IEnumerator OnHit(Car target, SpawnedPowerup instance);
        
        protected void EndHitEffect(SpawnedPowerup instance)
        {
            Destroy(instance.gameObject);
        }
    }
}