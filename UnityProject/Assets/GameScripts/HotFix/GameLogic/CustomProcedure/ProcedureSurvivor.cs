using System.Collections.Generic;
using GameLogic.Sokoban;
using GameLogic.Survivor;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureSurvivor : CustomProcedureBase
    {
        public ProcedureSurvivor(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Game._SurvivorGameRoot = new SurvivorGameRoot(new GameObject("SurvivorGameRoot"));
            Game._SurvivorGameRoot.FSMInit();
        }

        protected override void OnExit()
        {
            base.OnExit();
            Game._SurvivorGameRoot.Destroy();
            Game._SurvivorGameRoot = null;
        }
    }
}