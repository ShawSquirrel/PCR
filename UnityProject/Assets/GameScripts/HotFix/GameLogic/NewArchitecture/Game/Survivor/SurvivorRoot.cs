using GameLogic.NewArchitecture.Core;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorRoot : Core.Game, ISingleton
    {
        public static SurvivorRoot Instance => SingletonGroup.GetSingleton<SurvivorRoot>();
        private FSM<SurvivorProcedureType> _fsm;

        public void OnSingletonInit()
        {
        }


        public override void Awake()
        {
            base.Awake();
            InitUnit(null, "SurvivorRoot");
            InitFSM();
        }

        private void InitFSM()
        {
            _fsm = new FSM<SurvivorProcedureType>();
            _fsm.AddState(SurvivorProcedureType.Menu, new SurvivorProcedure_Menu(_fsm, this));
        }

        public override void Init()
        {
            base.Init();
            _fsm.StartState(SurvivorProcedureType.Menu);
        }
    }
}