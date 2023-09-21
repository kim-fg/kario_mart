using UnityEngine;

namespace KarioMart.Util
{
    public static class Maths
    {
        public static float ClampNeg1Pos1(float f) => Mathf.Clamp(f, -1f, 1f);
    }
}