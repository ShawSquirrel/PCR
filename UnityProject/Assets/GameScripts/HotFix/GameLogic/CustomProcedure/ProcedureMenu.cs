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
            GameEvent.AddEventListener(UIEvent.StartSokoban, StartSokoban);
        }

        protected override void RemoveEvent()
        {
            base.RegisterEvent();
            GameEvent.RemoveEventListener(UIEvent.StartSokoban, StartSokoban);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_Menu>();
        }

        private void StartSokoban()
        {
            mFSM.AddState(Enum_Procedure.SokobanGame, new ProcedureSokoban(mFSM, mTarget));
            mFSM.ChangeState(Enum_Procedure.SokobanGame);
        }

    }
}