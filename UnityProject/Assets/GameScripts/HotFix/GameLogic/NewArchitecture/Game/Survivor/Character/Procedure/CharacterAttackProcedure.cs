using GameConfig;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterAttackProcedure : CharacterProcedureBase
    {
        public CharacterAttackProcedure(FSM<Enum_ChracterState> fsm, CharacterSystem target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(TAnimState.Attack, false);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            mTarget.Move();
            mTarget.UpdateTowards();
        }
    }
}