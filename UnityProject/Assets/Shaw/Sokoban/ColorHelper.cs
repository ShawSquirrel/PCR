using UnityEngine;

namespace Shaw
{
    public static class ColorHelper
    {
        public static Color GetColorByHex(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out Color color))
            {
                return color;
            }
            return Color.white;
        }
    }
}