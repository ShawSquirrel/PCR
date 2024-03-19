﻿using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyWalkProcedure : EnemyProcedureBase
    {
        public EnemyWalkProcedure(FSM<Enum_EnemyState> fsm, EnemyCtl target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.PlayAnim(EAnimState.Walk, true);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (mTarget.HpDetect() == false)
            {
                mFSM.ChangeState(Enum_EnemyState.Die);
                return;
            }
            
            mTarget.UpdateTowards();
            mTarget.Move();
            
        }
    }
}