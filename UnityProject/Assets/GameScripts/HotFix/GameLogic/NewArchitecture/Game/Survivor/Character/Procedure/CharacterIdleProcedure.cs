using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterIdleProcedure : CharacterProcedureBase
    {
        public CharacterIdleProcedure(FSM<Enum_ChracterState> fsm, CharacterSystem target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(TAnimState.NoWeaponIdle, true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            if (mTarget.IsMoving == true)
            {
                mFSM.ChangeState(Enum_ChracterState.Walk);
                return;
            }
            mTarget.Move();
            mTarget.UpdateTowards();
        }
    }
}