using UnityEngine;

namespace GameBase
{
    public static class Vector3Helper
    {
        public static Vector2Int ToVector2Int(this Vector3 self)
        {
            return new Vector2Int(Mathf.RoundToInt(self.x), Mathf.RoundToInt(self.y));
        }
    }
}