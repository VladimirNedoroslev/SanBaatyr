using UnityEngine;

namespace Core.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 Randomize(this Vector3 vector2, float min = 0f, float max = 1f)
        {
            var xOffset = Random.Range(min, max);
            var yOffset = Random.Range(min, max);
            return new Vector3(vector2.x + xOffset, vector2.y + yOffset);
        }
    }
}