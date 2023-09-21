using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace KarioMart
{
    public class TimeTrial : MonoBehaviour
    {
        private float _lapStartTime;
        
        public void StartLap()
        {
            _lapStartTime = Time.time;
        }
    }
}
