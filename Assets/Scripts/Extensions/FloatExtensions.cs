using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public static class FloatExtensions
    {
        private static readonly Random rand = new Random();

        public static float Randomize(this float f, int percent = 10)
        {
            return f + (float)(f * NextPercent(percent));
        }

        public static float RandomizeWithSign(this float f, int percent)
        {
            return f + (f * Mathf.Abs((NextPercent(percent) * Mathf.Sign(percent))));
        }

        // public static float RandomizeWithSign(this int i, int percent)
        // {
        //     return ((float) i).RandomizeWithSign(percent);
        // }

        private static float NextPercent(int maxValue)
        {
            return rand.Next(-maxValue, maxValue) / 100f;
        }
        
    }
}