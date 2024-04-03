using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public class MainProcedureBase : AbstractState<MainProcedureType, MainRoot>
    {
        public MainProcedureBase(FSM<MainProcedureType> fsm, MainRoot target) : base(fsm, target)
        {
        }
    }
}