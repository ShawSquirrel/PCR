using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorMenuProcedure : SurvivorProcedureBase
    {
        public SurvivorMenuProcedure(FSM<Enum_SurvivorProcedure> fsm, SurvivorGameRoot target) : base(fsm, target)
        {
        }

        protected override void AddListen()
        {
            base.AddListen();
            
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SurvivorMenu>();
            Game._GameRoot.OpenVideoUI();
        }
    }
}