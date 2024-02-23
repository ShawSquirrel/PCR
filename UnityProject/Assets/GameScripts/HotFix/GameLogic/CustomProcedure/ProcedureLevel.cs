using System.Collections.Generic;
using GameBase;
using Sirenix.Utilities;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureLevel : CustomProcedureBase
    {
        public ProcedureLevel(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Log.Info("进入 ProcedureLevel ".SetColor(Color.green));
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            CheckMouseClick();
        }


        private void CheckMouseClick()
        {
            
        }
    }
}