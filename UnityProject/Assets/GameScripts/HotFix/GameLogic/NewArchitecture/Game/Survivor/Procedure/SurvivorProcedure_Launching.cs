﻿using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedure_Launching: SurvivorProcedureBase
    {
        public SurvivorProcedure_Launching(FSM<SurvivorProcedureType> fsm, SurvivorRoot target) : base(fsm, target)
        {
        }
        public override void AddListen()
        {
            base.AddListen();
            GameEvent.AddEventListener(EventID.ReturnMenu, OnReturnMenu);
        }

        public override void RemoveListen()
        {
            base.RemoveListen();
            GameEvent.RemoveEventListener(EventID.ReturnMenu, OnReturnMenu);
        }
        protected override void OnEnter()
        {
            base.OnEnter();
        }

        private void OnReturnMenu()
        {
            mFSM.ChangeState(SurvivorProcedureType.Menu);
            mTarget.Release();
        }
    }
}