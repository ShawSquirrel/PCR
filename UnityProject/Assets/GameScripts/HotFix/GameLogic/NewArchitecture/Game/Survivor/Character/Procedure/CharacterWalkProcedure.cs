using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterWalkProcedure : CharacterProcedureBase
    {
        public CharacterWalkProcedure(FSM<Enum_ChracterState> fsm, CharacterSystem target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.NoWeaponRun, true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (mTarget.IsMoving == false)
            {
                mFSM.ChangeState(Enum_ChracterState.Idle);
                return;
            }
            
            mTarget.Move();
            mTarget.UpdateTowards();
        }
    }
}