using UnityEngine;

namespace GameBase
{
    public static class GameObjectHelper
    {
        public static void SetRealActive(this GameObject self, bool isActive)
        {
            if (self.activeSelf == isActive)
                return;
            self.SetActive(isActive);
        }
    }
}