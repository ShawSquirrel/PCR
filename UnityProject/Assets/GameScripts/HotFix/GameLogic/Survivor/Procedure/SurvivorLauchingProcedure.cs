using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorLaunchingProcedure : SurvivorProcedureBase
    {
        public SurvivorLaunchingProcedure(FSM<Enum_SurvivorProcedure> fsm, ProcedureSurvivor target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Game._GameRoot.CloseVideoUI();
            GameModule.UI.ShowUI<UI_SurvivorStick>();
        }
    }
}