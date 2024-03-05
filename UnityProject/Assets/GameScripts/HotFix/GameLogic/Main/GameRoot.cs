using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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
            AddListen();
        }

        private void OnDestroy()
        {
            RemoveListen();
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        private void RemoveListen()
        {
            
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        private void AddListen()
        {
           
        }


        #region VideoUI()

        public void CloseVideoUI()
        {
            if (GameModule.UI.HasWindow<UI_Video>())
            {
                GameModule.UI.CloseWindow<UI_Video>();
                PauseVideo();
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

        #endregion


        #region Flash

        public async void OpenFlash(Action action = null)
        {
            await FlashStart();
            action?.Invoke();
            await FlashEnd();
        }

        private Material _mat;

        public async UniTask FlashStart()
        {
            _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            GameModule.UI.ShowUI<UI_Flash>(_mat);

            bool isComplete = false;

            DOTween.To(() => -1f, value => _mat.SetFloat("_Add", value), 1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }
        }

        public async UniTask FlashEnd()
        {
            // _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            bool isComplete = false;

            DOTween.To(() => 1f, value => _mat.SetFloat("_Add", value), -1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }

            GameModule.UI.CloseWindow<UI_Flash>();
        }

        #endregion
    }
}