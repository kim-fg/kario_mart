using System;
using System.Collections;
using System.Collections.Generic;
using KarioMart.Gamemodes;
using UnityEngine;

namespace KarioMart
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
