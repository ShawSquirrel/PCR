using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemyWalkProcedure : EnemyProcedureBase
    {
        public EnemyWalkProcedure(FSM<Enum_EnemyState> fsm, AEnemy target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Walk, true);
        }

        protected override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            mTarget.Move();
            mTarget.UpdateTowards();
        }
    }
}