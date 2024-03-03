using TEngine;
using UnityEngine;
using UnityEngine.Video;

namespace GameLogic
{
    public class VideoModule : Module
    {
        public VideoPlayer _VideoPlayer;
        protected override void Awake()
        {
            base.Awake();
            _VideoPlayer = GetComponentInChildren<VideoPlayer>();
        }

        public void SetRenderTexture(RenderTexture renderTexture)
        {
            _VideoPlayer.targetTexture = renderTexture;
        }

        public void PlayVideo(VideoClip clip, bool isLoop = false)
        {
            _VideoPlayer.clip = clip;
            Play(isLoop);
        }

        public void Play(bool isLoop)
        {
            _VideoPlayer.Play();
            _VideoPlayer.isLooping = isLoop;
        }
        public void Release()
        {
            _VideoPlayer.Pause();
            Object.Destroy(_VideoPlayer.targetTexture);
            _VideoPlayer.clip          = null;
            _VideoPlayer.targetTexture = null;
        }
    }
}
