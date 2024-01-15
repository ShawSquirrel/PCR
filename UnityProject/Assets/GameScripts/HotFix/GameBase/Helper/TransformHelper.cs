using UnityEngine;

namespace GameBase
{
    public static class TransformHelper
    {
        public static void Reset(this Transform self)
        {
            self.localPosition = Vector3.zero;
            self.localRotation = Quaternion.Euler(Vector3.zero);
            self.localScale    = Vector3.one;
            
        }
    }
}