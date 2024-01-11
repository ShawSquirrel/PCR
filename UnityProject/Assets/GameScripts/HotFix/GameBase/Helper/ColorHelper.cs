using UnityEngine;

namespace GameBase
{
    public static class ColorHelper
    {
        public static string ToHexString(this Color self)
        {
            return $"#{ColorUtility.ToHtmlStringRGB(self)}";
        }
    }
}