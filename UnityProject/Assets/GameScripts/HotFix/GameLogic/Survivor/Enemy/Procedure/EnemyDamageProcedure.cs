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
            mTarget.ResetSpeed();
            mTarget.PlayAnim(EAnimState.Damage, false, OnComplete);
        }

        public void OnComplete()
        {
            mFSM.ChangeState(Enum_EnemyState.Walk);
        }
        
    }
}