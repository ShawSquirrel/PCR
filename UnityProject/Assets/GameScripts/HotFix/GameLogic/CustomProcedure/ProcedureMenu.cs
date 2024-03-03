using System.IO;
using TEngine;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace GameLogic
{
    public class ProcedureMenu : CustomProcedureBase
    {
        public ProcedureMenu(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener(UIEvent.Sokoban_StartGame, StartSokoban);
        }

        protected override void RemoveEvent()
        {
            base.RegisterEvent();
            GameEvent.RemoveEventListener(UIEvent.Sokoban_StartGame, StartSokoban);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            RenderTexture renderTexture = new RenderTexture(1920, 1080, 24);
            GameModule.UI.ShowUI<UI_Menu>(new UI_MenuData
                                          {
                                              _RenderTexture =  renderTexture
                                          });
            CustomModule.VideoModule.PlayVideo(GameModule.Resource.LoadAsset<VideoClip>("优衣六星视频"), true);
            CustomModule.VideoModule.SetRenderTexture(renderTexture);
        }

        protected override void OnExit()
        {
            base.OnExit();
            CustomModule.VideoModule.Release();
        }

        private void StartSokoban()
        {
            mFSM.AddState(Enum_Procedure.SokobanGame, new ProcedureSokoban(mFSM, mTarget));
            mFSM.ChangeState(Enum_Procedure.SokobanGame);
        }

    }
}