using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class CharacterWalkProcedure : CharacterProcedureBase
    {
        public CharacterWalkProcedure(FSM<Enum_ChracterState> fsm, CharacterManager target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Walk, true);
        }
    }
}