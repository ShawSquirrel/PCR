using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class MapSystem : GameBase.System
    {
        private GameObject _map;

        #region Start Release

        public void Start()
        {
            Transform mapParent = Game._SurvivorGameRoot._Character.TFCharacter;
            LoadMap(mapParent);
        }

        public void Release()
        {
            RemoveMap();
        }

        #endregion

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