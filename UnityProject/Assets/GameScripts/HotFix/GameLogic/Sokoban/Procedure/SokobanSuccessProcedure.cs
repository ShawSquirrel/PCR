using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanSuccessProcedure : SokobanProcedureBase
    {
        public SokobanSuccessProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SokobanSuccess>();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            // GameEvent.AddEventListener(UIEventID.Sokoban_Menu, OnMenu);
            // GameEvent.AddEventListener(UIEventID.Sokoban_Restart, OnRestart);
            // GameEvent.AddEventListener(UIEventID.Sokoban_NextLevel, OnNextLevel);
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            // GameEvent.RemoveEventListener(UIEventID.Sokoban_Menu, OnMenu);
            // GameEvent.RemoveEventListener(UIEventID.Sokoban_Restart, OnRestart);
            // GameEvent.RemoveEventListener(UIEventID.Sokoban_NextLevel, OnNextLevel);
        }


        protected override void OnExit()
        {
            base.OnExit();
            _Root.OnReset();
        }
    }
}