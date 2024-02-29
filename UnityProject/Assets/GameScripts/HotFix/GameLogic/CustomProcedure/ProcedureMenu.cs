using System.IO;
using TEngine;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class ProcedureMenu : CustomProcedureBase
    {
        public ProcedureMenu(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener(UIEvent.StartGameEventID, StartGame);
        }

        protected override void RemoveEvent()
        {
            base.RegisterEvent();
            GameEvent.RemoveEventListener(UIEvent.StartGameEventID, StartGame);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_Menu>();
        }

        private void StartGame()
        {
            mFSM.AddState(Enum_Procedure.LoadGame, new ProcedureLoadGame(mFSM, mTarget));
            mFSM.ChangeState(Enum_Procedure.LoadGame);
        }

    }
}