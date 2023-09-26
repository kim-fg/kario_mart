using UnityEngine;

namespace KarioMart.Map
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private Collider2D[] checkpoints;
        [SerializeField] private Transform[] startGridPositions;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public Collider2D[] Checkpoints => checkpoints;
        public Transform[] StartGridPositions => startGridPositions;
    }
}
