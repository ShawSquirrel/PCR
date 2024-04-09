using GameConfig;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemyDieProcedure: EnemyProcedureBase
    {
        public EnemyDieProcedure(FSM<Enum_EnemyState> fsm, AEnemy target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.ResetSpeed();
            mTarget.SetColliderBoxEnable(false);
            mTarget.PlayAnim(EAnimState.Die, false, mTarget.Die);
        }
    }
}