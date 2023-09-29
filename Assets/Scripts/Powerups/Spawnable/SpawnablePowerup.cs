using System.Collections;
using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups.Spawnable
{
    public abstract class SpawnablePowerup : Powerup
    {
        [SerializeField] private float objectLifeTime = 3f;
        
        [Header("Spawning")]
        [SerializeField] private bool spawnBehind;
        [SerializeField] private GameObject spawnablePrefab;

        public float ObjectLifeTime => objectLifeTime;
        
        public override IEnumerator Activate(Car target)
        {
            var spawnDirection = spawnBehind ? -1 : 1;
            var spawnPos = target.transform.position + target.transform.up * spawnDirection;
            var spawnable = spawnablePrefab ? Instantiate(spawnablePrefab) : new GameObject("Spawned Powerup Item");
            spawnable.transform.position = spawnPos;

            yield return null;
        }

        public abstract IEnumerator OnHit(Car target);
    }
}