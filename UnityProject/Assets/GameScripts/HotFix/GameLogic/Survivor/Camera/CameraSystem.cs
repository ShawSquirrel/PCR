using Cinemachine;
using GameBase;
using Lean.Touch;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CameraSystem : GameBase.System
    {
        private SurvivorGameRoot Root => Game._SurvivorGameRoot;
        private CinemachineVirtualCamera _camera;


        public void Start()
        {
            _camera = GameModule.Resource.LoadAsset<GameObject>("SurvivorCamera").GetComponent<CinemachineVirtualCamera>();
            _camera.transform.SetParent(_Obj.transform);
            _camera.transform.position = Vector3.back * 10;


            Transform player = Root.GetCharacterTransform();
            SetFollowAndLookAt(player);
        }

        public void Release()
        {
            SetFollowAndLookAt(null);
            Object.Destroy(_camera.gameObject);
        }

        private void SetFollowAndLookAt(Transform follow, Transform lookAt = null)
        {
            _camera.Follow = follow;
            _camera.LookAt = lookAt ? lookAt : follow;
        }
    }
}