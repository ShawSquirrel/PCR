using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CustomProcedureModule : Module
    {
        public FSM<EProcedure> FSM;
        public IState CurrentState => FSM.CurrentState;
        protected override void Awake()
        {
            base.Awake();
            FSM = new FSM<EProcedure>();
            FSM.AddState(EProcedure.LoadConfigs, new ProcedureMenu(FSM, this));
            FSM.AddState(EProcedure.ProcedureMenu, new ProcedureMenu(FSM, this));
            FSM.AddState(EProcedure.LoadLevel1, new ProcedureLoadLevel1(FSM, this));
            FSM.AddState(EProcedure.ProcedureLevel, new ProcedureLevel(FSM, this));
            
            FSM.StartState(EProcedure.LoadConfigs);
        }

        public void Init()
        {
            Log.Info("CustomProcedureModule".SetColor(Color.green));
        }

        private void Update()
        {
            FSM.Update();
        }
    }
}
