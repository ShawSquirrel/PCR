using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanProcedureBase : AbstractState<Enum_SokobanProcedure, ProcedureSokoban>
    {
        public SokobanGameRoot _Root => SokobanGameRoot._Instance;
        public SokobanProcedureBase(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
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