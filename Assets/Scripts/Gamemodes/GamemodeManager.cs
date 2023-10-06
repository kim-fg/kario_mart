using UnityEngine;

namespace KarioMart.Gamemodes
{
    public class GamemodeManager : MonoBehaviour
    {
        public Gamemode ActiveGamemode { get; private set; }

        public void Init(Gamemode gamemodePrefab)
        {
            ActiveGamemode = Instantiate(gamemodePrefab);
        }

        public void BeginRace()
        {
            ActiveGamemode.BeginRace();
        }
    }
}
