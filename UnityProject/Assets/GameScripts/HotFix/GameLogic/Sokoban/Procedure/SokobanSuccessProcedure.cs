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
            GameEvent.AddEventListener(UIEvent.Sokoban_Menu, OnMenu);
            GameEvent.AddEventListener(UIEvent.Sokoban_Restart, OnRestart);
            GameEvent.AddEventListener(UIEvent.Sokoban_NextLevel, OnNextLevel);
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            GameEvent.RemoveEventListener(UIEvent.Sokoban_Menu, OnMenu);
            GameEvent.RemoveEventListener(UIEvent.Sokoban_Restart, OnRestart);
            GameEvent.RemoveEventListener(UIEvent.Sokoban_NextLevel, OnNextLevel);
        }


        protected override void OnExit()
        {
            base.OnExit();
            _Root.OnReset();
        }
    }
}