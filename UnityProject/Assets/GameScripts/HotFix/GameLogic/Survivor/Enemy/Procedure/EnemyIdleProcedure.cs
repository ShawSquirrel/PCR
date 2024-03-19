using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyIdleProcedure : EnemyProcedureBase
    {
        public EnemyIdleProcedure(FSM<Enum_EnemyState> fsm, EnemyCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Idle, true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (mTarget.CurTowards != Vector2.zero)
            {
                mFSM.ChangeState(Enum_EnemyState.Walk);
                return;
            }
        }
    }
}