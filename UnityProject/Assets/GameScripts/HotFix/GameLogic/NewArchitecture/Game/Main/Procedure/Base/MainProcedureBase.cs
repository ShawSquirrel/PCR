using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public abstract class MainProcedureBase : AbstractState<MainProcedureType, MainRoot>
    {
        public MainProcedureBase(FSM<MainProcedureType> fsm, MainRoot target) : base(fsm, target)
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