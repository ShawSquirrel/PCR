using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class EnemyAttackProcedure : EnemyProcedureBase
    {
        public EnemyAttackProcedure(FSM<Enum_EnemyState> fsm, EnemyCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            
            mTarget.PlayAnim(EAnimState.Attack, false);
        }
    }
}