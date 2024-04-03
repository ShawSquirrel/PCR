using GameLogic.NewArchitecture.Core;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public class MainRoot : Core.Game, ISingleton
    {
        public static MainRoot Instance => SingletonGroup.GetSingleton<MainRoot>();
        private FSM<MainProcedureType> _fsm;


        public void OnSingletonInit()
        {
        }

        public override void Awake()
        {
            base.Awake();
            InitUnit(null, "Root");
            InitFSM();
        }

        private void InitFSM()
        {
            _fsm = new FSM<MainProcedureType>();
            _fsm.AddState(MainProcedureType.Menu, new MainProcedure_Menu(_fsm, this));
            _fsm.AddState(MainProcedureType.Survivor, new MainProcedure_Survivor(_fsm, this));
        }

        public override void Init()
        {
            _fsm.StartState(MainProcedureType.Menu);
        }
    }
}