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
            base.OnEnter();
            AddListen();
        }

        protected override void OnExit()
        {
            base.OnExit();
            RemoveListen();
        }

        public virtual void AddListen()
        {
        }

        public virtual void RemoveListen()
        {
        }
    }
}