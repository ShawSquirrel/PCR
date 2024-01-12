using System.IO;
using TEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class ProcedureMenu : CustomProcedureBase
    {
        public ProcedureMenu(FSM<EProcedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }
    }
}