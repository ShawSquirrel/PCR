using Cinemachine;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    /// <summary>
    /// 角色控制
    /// </summary>
    public class CharacterCtl : EntityCtl
    {
        public CharacterCtl(string characterName) : base(characterName)
        {
            _chracter.layer = LayerMask.NameToLayer("Player");
            _body.layer = LayerMask.NameToLayer("Player");

            GameObject camera = GameModule.Resource.LoadAsset<GameObject>("SurvivorCamera");
            CinemachineVirtualCamera virtualCamera = camera.GetComponent<CinemachineVirtualCamera>();
            virtualCamera.Follow = _chracter.transform;
            virtualCamera.LookAt = _chracter.transform;
        }


        protected override void AddListen()
        {
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_Move, SetTowards);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_MoveStop, SetTowards);
        }

        protected override void Update()
        {
            // 更新UI血条
            GameEvent.Send(UIEventID_Survivor.SetBlood, _EntityBaseData._HP / _EntityBaseData._MaxHp);
        }


        public override void Damage(float value)
        {
            base.Damage(value);
            _EntityBaseData._HP -= value;
        }

        public override float GetAtk()
        {
            return _EntityBaseData._Atk;
        }
    }
}