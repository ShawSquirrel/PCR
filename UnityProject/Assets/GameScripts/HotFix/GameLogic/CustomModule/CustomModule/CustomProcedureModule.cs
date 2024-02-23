using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CustomProcedureModule : Module
    {
        public FSM<Enum_Procedure> _FSM;
        protected override void Awake()
        {
            base.Awake();
            // StartFlag();
            _FSM = new FSM<Enum_Procedure>();
            _FSM.AddState(Enum_Procedure.Menu, new ProcedureMenu(_FSM, this));
            _FSM.AddState(Enum_Procedure.LoadGame, new ProcedureLoadGame(_FSM, this));
            
            _FSM.StartState(Enum_Procedure.Menu);
        }

        private void StartFlag()
        {
            _FSM = new FSM<Enum_Procedure>();
            _FSM.AddState(Enum_Procedure.LoadConfigs, new ProcedureLoadConfigs(_FSM, this));
            _FSM.AddState(Enum_Procedure.Menu, new ProcedureMenu(_FSM, this));
            _FSM.AddState(Enum_Procedure.LoadLevel1, new ProcedureLoadLevel1(_FSM, this));
            _FSM.AddState(Enum_Procedure.ProcedureLevel, new ProcedureLevel(_FSM, this));
            
            _FSM.StartState(Enum_Procedure.LoadConfigs);
        }

        public void Init()
        {
            Log.Info("CustomProcedureModule".SetColor(Color.green));
        }

        private void Update()
        {
            _FSM.Update();
        }
    }
}
