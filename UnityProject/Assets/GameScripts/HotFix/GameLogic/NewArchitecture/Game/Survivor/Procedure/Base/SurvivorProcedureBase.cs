using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedureBase : AbstractState<SurvivorProcedureType, SurvivorRoot>
    {
        public SurvivorProcedureBase(FSM<SurvivorProcedureType> fsm, SurvivorRoot target) : base(fsm, target)
        {
        }
    }
}