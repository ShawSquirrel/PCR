using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class CharacterIdleProcedure : CharacterProcedureBase
    {
        public CharacterIdleProcedure(FSM<Enum_ChracterState> fsm, CharacterManager target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Idle, true);
        }
    }
}