using TEngine;
using UnityEngine;
using UnityEngine.Video;

namespace GameLogic
{
    public class ProcedureGameRoot : CustomProcedureBase
    {
        public ProcedureGameRoot(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            Game._GameRoot = new GameObject("GameRoot").AddComponent<GameRoot>();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener(UIEvent.Sokoban_StartGame, StartSokoban);
            GameEvent.AddEventListener(SurvivorEvent.Survivor_StartGame, OnSurvivorStartGame);
        }

        protected override void RemoveEvent()
        {
            base.RegisterEvent();
            GameEvent.RemoveEventListener(UIEvent.Sokoban_StartGame, StartSokoban);
            GameEvent.RemoveEventListener(SurvivorEvent.Survivor_StartGame, OnSurvivorStartGame);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameRoot._Instance.OpenVideoUI();
            GameModule.UI.ShowUI<UI_Menu>();
        }


        private void StartSokoban()
        {
            mFSM.AddState(Enum_Procedure.SokobanGame, new ProcedureSokoban(mFSM, mTarget));
            mFSM.ChangeState(Enum_Procedure.SokobanGame);
        }


        /// <summary>
        /// 开始幸存者游戏
        /// </summary>
        private void OnSurvivorStartGame()
        {
            GameRoot._Instance.StartFlash(() =>
            {
                GameModule.UI.CloseWindow<UI_Menu>();
                mFSM.AddState(Enum_Procedure.SurvivorGame, new ProcedureSurvivor(mFSM, mTarget));
                mFSM.ChangeState(Enum_Procedure.SurvivorGame);
            });
        }
    }
}