using System.IO;
using TEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class ProcedureLoadConfigs : CustomProcedureBase
    {
        public ProcedureLoadConfigs(FSM<EProcedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            ConfigSystem.Instance.Load();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            mFSM.ChangeState(EProcedure.ProcedureMenu);
        }
    }
}