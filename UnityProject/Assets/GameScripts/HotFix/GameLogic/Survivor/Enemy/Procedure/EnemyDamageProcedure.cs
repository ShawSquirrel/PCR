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
            mTarget.PlayAnim(TAnimState.Damage, false, OnComplete);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        public void OnComplete()
        {
            mFSM.ChangeState(Enum_EnemyState.Walk);
        }
        
    }
}