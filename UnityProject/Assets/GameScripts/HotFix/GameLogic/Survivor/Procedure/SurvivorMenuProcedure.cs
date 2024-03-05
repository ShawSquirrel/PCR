using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorMenuProcedure : SurvivorProcedureBase
    {
        public SurvivorMenuProcedure(FSM<Enum_SurvivorProcedure> fsm, ProcedureSurvivor target) : base(fsm, target)
        {
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener(SurvivorEvent.Survivor_StartGame, OnStartGame);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SurvivorMenu>();
        }
    }
}