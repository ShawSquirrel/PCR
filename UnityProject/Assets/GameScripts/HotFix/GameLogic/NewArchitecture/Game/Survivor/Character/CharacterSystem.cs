using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterSystem : Core.System
    {
        public FSM<Enum_ChracterState> _FSM = new FSM<Enum_ChracterState>();
        public CharacterModel Model => SurvivorRoot.Instance.GetModel<CharacterModel>();

        public override void Awake()
        {
            base.Awake();
            _FSM.AddState(Enum_ChracterState.Idle, new CharacterIdleProcedure(_FSM, this));
            _FSM.AddState(Enum_ChracterState.Walk, new CharacterWalkProcedure(_FSM, this));
            _FSM.AddState(Enum_ChracterState.Attack, new CharacterAttackProcedure(_FSM, this));
        }

        public override void Init()
        {
            base.Init();
            Utility.Unity.AddUpdateListener(_FSM.Update);
            Utility.Unity.AddFixedUpdateListener(_FSM.FixedUpdate);
            _FSM.StartState(Enum_ChracterState.Idle);
        }

        public override void Release()
        {
            base.Release();
            Utility.Unity.RemoveUpdateListener(_FSM.Update);
            Utility.Unity.RemoveFixedUpdateListener(_FSM.FixedUpdate);
            _FSM.ExitState();
        }

        public override void Destroy()
        {
            base.Destroy();
            _FSM.Clear();
            _FSM = null;
        }

        public void PlayAnim(EAnimState state, bool b)
        {
            if (Model == null) return;
            Model._CharacterComponent.Value._Anim.Play(state, b);
        }

        public void Move()
        {
            Rigidbody2D rigidbody2D = Model._CharacterComponent.Value._Rigidbody2D;
            Vector2 speed = SurvivorRoot.Instance.GetModel<CharacterModel>()._CharacterSpeed.Value;
            rigidbody2D.velocity = speed;
        }

        public void Still()
        {
            Rigidbody2D rigidbody2D = Model._CharacterComponent.Value._Rigidbody2D;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}