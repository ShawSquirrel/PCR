using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;
using Utility = TEngine.Utility;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class ACharacter : ICharacter
    {
        public virtual IUnit GetUnit()
        {
            return null;
        }

       public FSM<Enum_ChracterState> _FSM = new FSM<Enum_ChracterState>();
        public CharacterModel CharacterModel => SurvivorRoot.Instance.GetModel<CharacterModel>();
        public Vector2 Speed => SurvivorRoot.Instance.GetModel<CharacterModel>()._CharacterSpeed.Value;

        public bool IsMoving => Speed != Vector2.zero;

        public virtual void Create()
        {
            _FSM.AddState(Enum_ChracterState.Idle, new CharacterIdleProcedure(_FSM, this));
            _FSM.AddState(Enum_ChracterState.Walk, new CharacterWalkProcedure(_FSM, this));
            _FSM.AddState(Enum_ChracterState.Attack, new CharacterAttackProcedure(_FSM, this));
        }

        public virtual void Init()
        {
            Utility.Unity.AddUpdateListener(_FSM.Update);
            Utility.Unity.AddFixedUpdateListener(_FSM.FixedUpdate);
            _FSM.StartState(Enum_ChracterState.Idle);
        }

        public virtual void Release()
        {
            Utility.Unity.RemoveUpdateListener(_FSM.Update);
            Utility.Unity.RemoveFixedUpdateListener(_FSM.FixedUpdate);
            _FSM.ExitState();
        }

        public virtual void Destroy()
        {
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