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
            Game._SurvivorGameRoot = new SurvivorGameRoot(new GameObject("SurvivorGameRoot"));

          
        }
    }
}