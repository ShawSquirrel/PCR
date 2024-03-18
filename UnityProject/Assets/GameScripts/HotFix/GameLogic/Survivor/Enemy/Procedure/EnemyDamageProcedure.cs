using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class EnemyDamageProcedure : EnemyProcedureBase
    {
        public EnemyDamageProcedure(FSM<Enum_EnemyState> fsm, EnemyCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Damage, false);
        }
    }
}