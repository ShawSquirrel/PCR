using GameLogic.Sokoban;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureSokoban : CustomProcedureBase
    {
        public SokobanGameRoot _GameRoot;

        public ProcedureSokoban(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            _GameRoot = new GameObject("SokobanGameRoot").AddComponent<SokobanGameRoot>();

        }
    }
}