using Cinemachine;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class CameraManager : GameBase.Manager
    {
        private CinemachineVirtualCamera _camera;
        public override void Awake()
        {
            base.Awake();
            _camera = GameModule.Resource.LoadAsset<GameObject>("SokobanCamera").GetComponent<CinemachineVirtualCamera>();
            _camera.transform.SetParent(_Obj.transform);
            _camera.transform.position = Vector3.back * 10;
        }

        public void SetFollowAndLookAt(Transform follow, Transform lookAt = null)
        {
            _camera.Follow = follow;
            _camera.LookAt = lookAt ? lookAt : follow;

        }


    }
}