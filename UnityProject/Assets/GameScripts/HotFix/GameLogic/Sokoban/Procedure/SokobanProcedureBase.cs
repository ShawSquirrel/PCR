using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanProcedureBase : AbstractState<Enum_SokobanProcedure, ProcedureSokoban>
    {
        public SokobanGameRoot _Root => SokobanGameRoot._Instance;
        public SokobanProcedureBase(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            RegisterEvent();
        }

        protected override void OnExit()
        {
            base.OnExit();
            RemoveEvent();
        }

        protected virtual void RegisterEvent()
        {
        }

        protected virtual void RemoveEvent()
        {
        }

        protected void OnMenu()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameMenu);
        }

        protected void OnRestart()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
        }


        protected void OnNextLevel()
        {
            _Root._Level.NextLevel();
            mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
        }
        
        protected void OnSelectLevelEvent(string levelName)
        {
            if (_Root._Level.SetCurLoadLevel(levelName))
            {
                mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
            }
        }
    }
}