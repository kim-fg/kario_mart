using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups
{
    [CreateAssetMenu(menuName = "Powerup/Spawning")]
    public class SpawningPowerup : Powerup
    {
        [SerializeField] private bool spawnBehind;
        [SerializeField] private GameObject spawnablePrefab;
        
        public override void Activate(Car target)
        {
            var spawnDirection = spawnBehind ? -1 : 1;
            var spawnPos = target.transform.position + target.transform.up * spawnDirection;
            var spawnable = spawnablePrefab ? Instantiate(spawnablePrefab) : new GameObject("Spawned Powerup Item");
            spawnable.transform.position = spawnPos;
        }
    }
}