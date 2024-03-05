using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorProcedureBase : AbstractState<Enum_SurvivorProcedure, ProcedureSurvivor>
    {
        public SurvivorProcedureBase(FSM<Enum_SurvivorProcedure> fsm, ProcedureSurvivor target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            RegisterEvent();
            Log.Info($"当前的状态 {mFSM.CurrentStateId}");
            base.OnEnter();
        }

        protected override void OnExit()
        {
            RemoveEvent();
            base.OnExit();
        }

        protected virtual void RegisterEvent()
        {
        }

        protected virtual void RemoveEvent()
        {
        }


        protected void OnStartGame()
        {
            GameRoot._Instance.StartFlash(() =>
                                          {
                                              GameModule.UI.CloseWindow<UI_SurvivorMenu>();
                                              mFSM.ChangeState(Enum_SurvivorProcedure.GameLaunching);
                                          });
        }
    }
}