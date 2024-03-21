using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class MapSystem : GameBase.System
    {
        public override void Awake()
        {
            base.Awake();
            
        }

        public void LoadMap(Transform parent)
        {
            GameObject map = GameModule.Resource.LoadAsset<GameObject>("Plane");
            map.transform.SetParent(parent);
            map.transform.localPosition = new Vector3(0, 0, 10);
        }
    }
}