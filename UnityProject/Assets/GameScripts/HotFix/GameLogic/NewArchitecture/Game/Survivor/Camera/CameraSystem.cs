using Cinemachine;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CameraSystem : Core.System
    {
        private CinemachineVirtualCamera _camera;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            _camera = GameModule.Resource.LoadAsset<GameObject>("SurvivorCamera").GetComponent<CinemachineVirtualCamera>();
            _camera.transform.SetParent(SurvivorRoot.Instance.Unit._TF);
            _camera.transform.position = Vector3.back * 10;


            Transform player = SurvivorRoot.Instance.GetModel<CharacterModel>()._Unit.Value._TF;
            SetFollowAndLookAt(player);
        }

        public override void Release()
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