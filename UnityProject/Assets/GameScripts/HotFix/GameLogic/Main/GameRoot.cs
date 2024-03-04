using System;
using TEngine;
using UnityEngine;
using UnityEngine.Video;

namespace GameLogic
{
    public class GameRoot : GameBase.GameRoot
    {
        public static GameRoot _Instance => Game._GameRoot;
        protected void Awake()
        {
            GameEvent.AddEventListener(UIEvent.PauseVideo, PauseVideo);
        }

        public RenderTexture PlayVideo()
        {
            RenderTexture renderTexture = new RenderTexture(1920, 1080, 24);
            CustomModule.VideoModule.PlayVideo(GameModule.Resource.LoadAsset<VideoClip>("优衣六星视频"), true);
            CustomModule.VideoModule.SetRenderTexture(renderTexture);
            return renderTexture;
        }

        public void PauseVideo()
        {
            CustomModule.VideoModule.Release();
        }

        #region VideoUI()

        public void CloseVideoUI()
        {
            if (GameModule.UI.HasWindow<UI_Video>())
            {
                GameModule.UI.CloseWindow<UI_Video>();
            }
        }
        public void OpenVideoUI()
        {
            if (!GameModule.UI.HasWindow<UI_Video>())
            {
                RenderTexture renderTexture = PlayVideo();
                GameModule.UI.ShowUI<UI_Video>(new UI_VideoData() { _RenderTexture = renderTexture });
            }
        }


        #endregion
    }
}