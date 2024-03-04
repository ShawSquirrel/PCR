using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanFlashProcedure : SokobanProcedureBase
    {
        public SokobanFlashProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }
    }
}