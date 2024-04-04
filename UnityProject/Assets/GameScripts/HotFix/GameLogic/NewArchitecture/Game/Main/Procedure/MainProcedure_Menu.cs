using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public class MainProcedure_Menu : MainProcedureBase
    {
        public MainProcedure_Menu(FSM<MainProcedureType> fsm, MainRoot target) : base(fsm, target)
        {
        }

        public override void AddListen()
        {
            GameEvent.AddEventListener(EventID.SelectSurvivorGameID, OnSelectSurvivorGame);
        }

        public override void RemoveListen()
        {
            GameEvent.RemoveEventListener(EventID.SelectSurvivorGameID, OnSelectSurvivorGame);
        }


        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_Menu>();
        }
        
        private void OnSelectSurvivorGame()
        {
            Log.Info("进入割草游戏");
            GameModule.UI.CloseWindow<UI_Menu>();
            
            MainRoot.Instance.GetSystem<ProcedureSystem>().ChangeState(MainProcedureType.Survivor);
        }
    }
}