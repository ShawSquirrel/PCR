using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CustomProcedureModule : Module
    {
        public FSM<Enum_Procedure> _FSM;
        protected void Start()
        {
            
            _FSM = new FSM<Enum_Procedure>();
            _FSM.AddState(Enum_Procedure.GameRoot, new ProcedureGameRoot(_FSM, this));
            
            _FSM.StartState(Enum_Procedure.GameRoot);
        }

        private void Update()
        {
            _FSM.Update();
        }
    }
}
