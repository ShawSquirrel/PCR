using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class EnemyDieProcedure: EnemyProcedureBase
    {
        public EnemyDieProcedure(FSM<Enum_EnemyState> fsm, EnemyCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.ResetSpeed();
            mTarget.SetColliderBoxEnable(false);
            mTarget.PlayAnim(TAnimState.Die, false, mTarget.Die);
        }
    }
}