using GameConfig;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemyDamageProcedure : EnemyProcedureBase
    {
        public EnemyDamageProcedure(FSM<Enum_EnemyState> fsm, AEnemy target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.ResetSpeed();
            mTarget.PlayAnim(TAnimState.Damage, false, OnComplete);
        }

        public void OnComplete()
        {
            mFSM.ChangeState(Enum_EnemyState.Walk);
        }
        
    }
}