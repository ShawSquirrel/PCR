using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public class ProcedureSystem : Core.System
    {
        private FSM<MainProcedureType> _fsm;

        public override void Create()
        {
            base.Create();
            InitFSM();
        }

        private void InitFSM()
        {
            _fsm = new FSM<MainProcedureType>();
            _fsm.AddState(MainProcedureType.Menu, new MainProcedure_Menu(_fsm, MainRoot.Instance));
            _fsm.AddState(MainProcedureType.Survivor, new MainProcedure_Survivor(_fsm, MainRoot.Instance));
        }

        public override void Init()
        {
            _fsm.StartState(MainProcedureType.Menu);
        }

        public void ChangeState(MainProcedureType type)
        {
            _fsm.ChangeState(type);
        }
    }
}