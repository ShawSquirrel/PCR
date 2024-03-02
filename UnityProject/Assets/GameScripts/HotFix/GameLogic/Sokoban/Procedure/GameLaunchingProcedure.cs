using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class GameLaunchingProcedure : SokobanProcedureBase
    {
        public GameLaunchingProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            _Root._Map.AddListen();
        }


        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener(UIEvent.Sokoban_Success, OnSuccess);
        }

        protected override void RemoveEvent()
        {
            base.RegisterEvent();
            GameEvent.RemoveEventListener(UIEvent.Sokoban_Success, OnSuccess);
        }

        private void OnSuccess()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameSuccess);
        }
        

        protected override void OnExit()
        {
            base.OnExit();
            _Root._Map.RemoveListen();
        }
    }
}