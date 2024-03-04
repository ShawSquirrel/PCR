using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanLaunchingProcedure : SokobanProcedureBase
    {
        private UI_Launching _UILaunching;
        public SokobanLaunchingProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            
            _Root._Map.AddListen();

            GameModule.UI.ShowUI<UI_Launching>();   
            GameRoot._Instance.CloseVideoUI();

        }


        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener(UIEvent.Sokoban_Success, OnSuccess);
            GameEvent.AddEventListener(UIEvent.Sokoban_Menu, OnMenu);
            GameEvent.AddEventListener<Vector2Int>(UIEvent.Sokoban_Move, OnMove);
            // GameEvent.AddEventListener(UIEvent.Sokoban_Restart, OnRestart);
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            GameEvent.RemoveEventListener(UIEvent.Sokoban_Success, OnSuccess);
            GameEvent.RemoveEventListener(UIEvent.Sokoban_Menu, OnMenu);
            GameEvent.RemoveEventListener<Vector2Int>(UIEvent.Sokoban_Move, OnMove);
            // GameEvent.RemoveEventListener(UIEvent.Sokoban_Restart, OnRestart);

        }

        private void OnMove(Vector2Int vector2Int)
        {
            _Root._Map.Move(vector2Int);
        }

        private void OnSuccess()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameSuccess);
        }

        protected override void OnMenu()
        {
            _Root.OnReset();
            base.OnMenu();
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameModule.UI.CloseWindow<UI_Launching>();
        }
    }
}