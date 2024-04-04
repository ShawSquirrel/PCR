using GameLogic.Survivor;
using TEngine;
using UnityEngine;
using UnityEngine.Video;
using AudioType = TEngine.AudioType;

namespace GameLogic
{
    public class ProcedureGameRoot : CustomProcedureBase
    {
        public ProcedureGameRoot(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            GameObject obj = new GameObject("GameRoot");
            Game._GameRoot = new GameRoot(obj);
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            // GameEvent.AddEventListener(UIEventID.Sokoban_StartGame, StartSokoban);
            GameEvent.AddEventListener(EventID_Survivor.Survivor_StartGame, OnSurvivorStartGame);
        }

        protected override void RemoveEvent()
        {
            base.RegisterEvent();
            // GameEvent.RemoveEventListener(UIEventID.Sokoban_StartGame, StartSokoban);
            GameEvent.RemoveEventListener(EventID_Survivor.Survivor_StartGame, OnSurvivorStartGame);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameRoot._Instance.OpenVideoUI();
            GameModule.UI.ShowUI<UI_Menu>();

            GameModule.Audio.Play(AudioType.Music, "公主连结-主题曲", true);
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