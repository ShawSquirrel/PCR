using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorResultProcedure : SurvivorProcedureBase
    {
        public SurvivorResultProcedure(FSM<Enum_SurvivorProcedure> fsm, SurvivorGameRoot target) : base(fsm, target)
        {
        }

        protected override void AddListen()
        {
            base.AddListen();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_Result>();
        }
    }
}