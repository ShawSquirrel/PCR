using Cinemachine;
using GameBase;
using Lean.Touch;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CameraManager : GameBase.System
    {
        private CinemachineVirtualCamera _camera;
        public override void Awake()
        {
            base.Awake();
            

        }

        public override void Init()
        {
            base.Init();
            _camera = GameModule.Resource.LoadAsset<GameObject>("SurvivorCamera").GetComponent<CinemachineVirtualCamera>();
            _camera.transform.SetParent(_Obj.transform);
            _camera.transform.position = Vector3.back * 10;
        }


        public void SetFollowAndLookAt(Transform follow, Transform lookAt = null)
        {
            _camera.Follow = follow;
            _camera.LookAt = lookAt ? lookAt : follow;

        }

        public void OnReset()
        {
            _camera.Follow = null;
            _camera.LookAt = null;
        }
    }
}