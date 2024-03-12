using TEngine;

namespace GameLogic.Survivor
{
    public class SurvivorProcedureBase : AbstractState<Enum_SurvivorProcedure, SurvivorGameRoot>
    {
        public SurvivorProcedureBase(FSM<Enum_SurvivorProcedure> fsm, SurvivorGameRoot target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            AddListen();
            Log.Info($"当前的状态 {mFSM.CurrentStateId}");
            base.OnEnter();
        }

        protected override void OnExit()
        {
            RemoveEvent();
            base.OnExit();
        }

        protected virtual void AddListen()
        {
        }

        protected virtual void RemoveEvent()
        {
        }



    }
}