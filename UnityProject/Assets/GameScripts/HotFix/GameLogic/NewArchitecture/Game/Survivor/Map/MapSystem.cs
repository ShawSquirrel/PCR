using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class MapSystem : Core.System
    {
        private GameObject _map;


        public override void Init()
        {
            Transform mapParent = SurvivorRoot.Instance.GetModel<CharacterModel>()._Unit.Value._TF;
            LoadMap(mapParent);
        }

        public override void Release()
        {
            RemoveMap();
        }


        private void LoadMap(Transform parent)
        {
            _map = GameModule.Resource.LoadAsset<GameObject>("Plane");
            _map.transform.SetParent(parent);
            _map.transform.localPosition = new Vector3(0, 0, 10);
        }

        private void RemoveMap()
        {
            Object.Destroy(_map);
        }
    }
}