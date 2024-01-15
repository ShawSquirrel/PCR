using TEngine;

namespace GameLogic
{
    public class CustomProcedureBase : AbstractState<EProcedure, CustomProcedureModule>
    {
        protected CustomProcedureBase(FSM<EProcedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            RegisterEvent();
        }

        protected override void OnExit()
        {
            base.OnExit();
            RemoveEvent();
        }

        protected virtual void RegisterEvent()
        {
            
        }
        protected virtual void RemoveEvent()
        {
            
        }
    }

}