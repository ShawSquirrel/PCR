using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedure_Launching: SurvivorProcedureBase
    {
        public SurvivorProcedure_Launching(FSM<SurvivorProcedureType> fsm, SurvivorRoot target) : base(fsm, target)
        {
        }

        protected override void AddListen()
        {
            base.AddListen();
            GameEvent.AddEventListener(EventID.ReturnMenu, OnReturnMenu);
        }

        protected override void RemoveListen()
        {
            base.RemoveListen();
            GameEvent.RemoveEventListener(EventID.ReturnMenu, OnReturnMenu);
        }
        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SurvivorStick>();
            GameModule.UI.ShowUI<UI_Infomation>();
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameModule.UI.CloseWindow<UI_SurvivorStick>();
            GameModule.UI.CloseWindow<UI_Infomation>();
            GameModule.UI.CloseWindow<UI_Result>();
        }
        
        private void OnReturnMenu()
        {
            mFSM.ChangeState(SurvivorProcedureType.Menu);
            mTarget.Release();
        }
    }
}