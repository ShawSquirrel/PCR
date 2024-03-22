using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorGameTestProcedure : SurvivorProcedureBase
    {
        public SurvivorGameTestProcedure(FSM<Enum_SurvivorProcedure> fsm, SurvivorGameRoot target) : base(fsm, target)
        {
        }

        protected override void AddListen()
        {
            base.AddListen();
            
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            
        }
    }
}