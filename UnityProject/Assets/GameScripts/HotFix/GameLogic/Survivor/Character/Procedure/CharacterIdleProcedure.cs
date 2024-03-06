using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterIdleProcedure : CharacterProcedureBase
    {
        public CharacterIdleProcedure(FSM<Enum_ChracterState> fsm, CharacterCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Idle, true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (mTarget.CharacterData._Towards != Vector2.zero)
            {
                mFSM.ChangeState(Enum_ChracterState.Walk);
                return;
            }
        }
    }
}