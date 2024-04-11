using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class CharacterAttackProcedure : CharacterProcedureBase
    {
        public CharacterAttackProcedure(FSM<Enum_ChracterState> fsm, CharacterCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(TAnimState.Attack, false);
        }
    }
}