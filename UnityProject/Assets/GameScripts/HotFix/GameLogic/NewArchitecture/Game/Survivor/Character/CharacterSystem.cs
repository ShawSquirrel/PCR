using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterSystem : Core.System
    {
        public FSM<Enum_ChracterState> _FSM = new FSM<Enum_ChracterState>();
        public CharacterModel CharacterModel => SurvivorRoot.Instance.GetModel<CharacterModel>();
        public Vector2 Speed => SurvivorRoot.Instance.GetModel<CharacterModel>()._CharacterSpeed.Value;

        public bool IsMoving => Speed != Vector2.zero;

        public override void Create()
        {
            base.Create();
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

        public void PlayAnim(TAnimState state, bool b)
        {
            if (CharacterModel == null) return;
            CharacterModel._CharacterComponent.Value._Anim.Play(state, b);
        }

        public void Move()
        {
            Rigidbody2D rigidbody2D = CharacterModel._CharacterComponent.Value._Rigidbody2D;
            
            rigidbody2D.velocity = Speed * 2;
        }

        public void Still()
        {
            Rigidbody2D rigidbody2D = CharacterModel._CharacterComponent.Value._Rigidbody2D;
            rigidbody2D.velocity = Vector2.zero;
        }

        public void UpdateTowards()
        {
            Vector2 speed = SurvivorRoot.Instance.GetModel<CharacterModel>()._CharacterSpeed.Value;
            switch (speed.x)
            {
                case > 0:
                    SetFlipX(false);
                    break;
                case < 0:
                    SetFlipX(true);
                    break;
            }
        }
        
        protected virtual void SetFlipX(bool isLeft)
        {
            Transform body = SurvivorRoot.Instance.GetModel<CharacterModel>()._CharacterComponent.Value._Body._TF;
            Vector3 scale = body.localScale;
            if (scale.x > 0 && isLeft)
            {
                scale.Set(-scale.x, scale.y, scale.z);
            }
            else if (scale.x < 0 && !isLeft)
            {
                scale.Set(-scale.x, scale.y, scale.z);
            }
            else
            {
                return;
            }

            body.localScale = scale;
        }
    }
}