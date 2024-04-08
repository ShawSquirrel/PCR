using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedureBase : AbstractState<SurvivorProcedureType, SurvivorRoot>
    {
        public SurvivorProcedureBase(FSM<SurvivorProcedureType> fsm, SurvivorRoot target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            AddListen();
            base.OnEnter();
        }

        protected override void OnExit()
        {
            RemoveListen();
            base.OnExit();
        }

        protected virtual void AddListen()
        {
        }

        protected virtual void RemoveListen()
        {
        }
    }
}