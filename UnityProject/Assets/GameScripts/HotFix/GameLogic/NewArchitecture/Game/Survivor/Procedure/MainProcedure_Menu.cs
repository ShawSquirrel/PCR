using GameLogic.NewArchitecture.Game.Main;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedure_Menu : SurvivorProcedureBase
    {
        public SurvivorProcedure_Menu(FSM<SurvivorProcedureType> fsm, SurvivorRoot target) : base(fsm, target)
        {
        }

        public override void AddListen()
        {
            base.AddListen();
            GameEvent.AddEventListener(EventID.ReturnSelectGameID, OnReturnSelectGame);
        }

        public override void RemoveListen()
        {
            base.OnExit();
            GameEvent.RemoveEventListener(EventID.ReturnSelectGameID, OnReturnSelectGame);
        }


        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SurvivorMenu>();
        }
        

        private void OnReturnSelectGame()
        {
            GameModule.UI.CloseWindow<UI_SurvivorMenu>();
            MainRoot.Instance.GetSystem<ProcedureSystem>().ChangeState(MainProcedureType.Menu);
        }
    }
}