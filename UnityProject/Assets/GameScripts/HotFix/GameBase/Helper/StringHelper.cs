using UnityEngine;

namespace GameBase
{
    public static class StringHelper
    {
        public static string SetColor(this string self, Color color)
        {
            return $"<color={color.ToHexString()}>{self}</color>";
        }
    }
}