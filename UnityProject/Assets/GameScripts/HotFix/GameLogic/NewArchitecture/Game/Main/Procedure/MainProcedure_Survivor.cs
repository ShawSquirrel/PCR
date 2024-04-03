using GameLogic.NewArchitecture.Game.Survivor;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public class MainProcedure_Survivor : MainProcedureBase
    {
        public SurvivorRoot SurvivorRoot => SurvivorRoot.Instance;
        public MainProcedure_Survivor(FSM<MainProcedureType> fsm, MainRoot target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            SurvivorRoot.Awake();
        }

        protected override void OnExit()
        {
            SurvivorRoot.Destroy();
        }
    }
}