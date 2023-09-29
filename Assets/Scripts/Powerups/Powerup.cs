using KarioMart.CarSystem;
using UnityEngine;

namespace KarioMart.Powerups
{
    public abstract class Powerup : ScriptableObject
    {
        public abstract void Activate(Car target);
    }
}
