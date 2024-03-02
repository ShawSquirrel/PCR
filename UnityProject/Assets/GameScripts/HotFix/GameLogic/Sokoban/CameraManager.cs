using Cinemachine;
using Lean.Touch;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class CameraManager : GameBase.Manager
    {
        private CinemachineVirtualCamera _camera;
        private LeanDragCamera _leanDragCamera;
        public override void Awake()
        {
            base.Awake();
            _camera = GameModule.Resource.LoadAsset<GameObject>("SokobanCamera").GetComponent<CinemachineVirtualCamera>();
            _camera.transform.SetParent(_Obj.transform);
            _camera.transform.position = Vector3.back * 10;

            _leanDragCamera = _camera.gameObject.AddComponent<LeanDragCamera>();
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

        public void SetDragActive(bool isEnable)
        {
            _leanDragCamera.enabled = isEnable;
        }
    }
}