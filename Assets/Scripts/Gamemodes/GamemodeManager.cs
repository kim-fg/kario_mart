using UnityEngine;

namespace KarioMart.Gamemodes
{
    public class GamemodeManager : MonoBehaviour
    {
        [SerializeField] private Gamemode debugSelectedGamemodePrefab;
        
        public Gamemode ActiveGamemode { get; private set; }

        private void Start()
        {
            Init(debugSelectedGamemodePrefab);
        }

        public void Init(Gamemode gamemodePrefab)
        {
            ActiveGamemode = Instantiate(gamemodePrefab);
        }
    }
}
