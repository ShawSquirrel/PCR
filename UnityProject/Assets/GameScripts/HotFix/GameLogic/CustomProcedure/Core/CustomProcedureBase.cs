using TEngine;

namespace GameLogic
{
    public class CustomProcedureBase : AbstractState<Enum_Procedure, CustomProcedureModule>
    {
        protected CustomProcedureBase(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
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

        protected virtual void LoadMap()
        {
            
        }
    }

}