using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterWalkProcedure : CharacterProcedureBase
    {
        public CharacterWalkProcedure(FSM<Enum_ChracterState> fsm, CharacterCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Walk, true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            mTarget.Move();
            mTarget.UpdateTowards();
            
            if (mTarget.CharacterData._Towards == Vector2.zero)
            {
                mFSM.ChangeState(Enum_ChracterState.Idle);
                return;
            }
        }
    }
}