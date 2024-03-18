using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameBase;
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
            CustomModule.VideoModule.PlayVideo(GameModule.Resource.LoadAsset<VideoClip>("公主佩可视频2"), true);
            CustomModule.VideoModule.SetRenderTexture(renderTexture);
            return renderTexture;
        }

        public void PauseVideo()
        {
            CustomModule.VideoModule.Release();
        }

        #endregion


        #region Flash

        public async void StartFlash(Action action = null)
        {
            _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash").Instantiate();
            GameModule.UI.ShowUI<UI_Flash>(_mat);
            bool isComplete = false;
            DOTween.To(() => -1f, value => _mat.SetFloat("_Add", value), 1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);
            
            await UniTask.WaitUntil(() => isComplete);
            
            action?.Invoke();

            isComplete = false;

            DOTween.To(() => 1f, value => _mat.SetFloat("_Add", value), -1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            await UniTask.WaitUntil(() => isComplete);

            GameModule.UI.CloseWindow<UI_Flash>();
        }

        public IEnumerator OpenFlash(Action action = null)
        {
            yield return FlashStart();
            action?.Invoke();
            yield return FlashEnd();
        }

        private Material _mat;

        public IEnumerator FlashStart()
        {
            _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            GameModule.UI.ShowUI<UI_Flash>(_mat);
            bool isComplete = false;

            DOTween.To(() => -1f, value => _mat.SetFloat("_Add", value), 1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);
            while (!isComplete)
            {
                yield return null;
            }
        }

        public IEnumerator FlashEnd()
        {
            // _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            bool isComplete = false;

            DOTween.To(() => 1f, value => _mat.SetFloat("_Add", value), -1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                yield return null;
            }

            GameModule.UI.CloseWindow<UI_Flash>();
        }

        #endregion

        public GameRoot(GameObject obj) : base(obj)
        {
        }
    }
}