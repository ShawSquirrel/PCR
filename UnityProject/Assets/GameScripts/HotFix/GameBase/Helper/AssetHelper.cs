using UnityEngine;

namespace GameBase
{
    public static class AssetHelper
    {
        public static T Instantiate<T>(this T self) where T : Object
        {
            return Object.Instantiate(self);
        }
    }
}