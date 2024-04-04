using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedureSystem : Core.System
    {
        private FSM<SurvivorProcedureType> _fsm;
        public override void Awake()
        {
            base.Awake();
            InitFSM();
        }

        private void InitFSM()
        {
            _fsm = new FSM<SurvivorProcedureType>();
            _fsm.AddState(SurvivorProcedureType.Menu, new SurvivorProcedure_Menu(_fsm, SurvivorRoot.Instance));
        }

        public override void Init()
        {
            base.Init();
            _fsm.StartState(SurvivorProcedureType.Menu);
        }

        public void ChangeState(SurvivorProcedureType type)
        {
            _fsm.ChangeState(type);
        }

        public override void Destroy()
        {
            base.Destroy();
            Release();
            _fsm.Clear();
        }
    }
}