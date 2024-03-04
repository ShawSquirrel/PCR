using System.Collections;
using System.Collections.Generic;
using GameBase;
using UnityEngine;
using UnityEngine.Video;

namespace GameLogic
{
    public class VideoPlayerManager : MonoSingleton<VideoPlayerManager>
    {
        private VideoPlayer _videoPlayer;
        protected override void Awake()
        {
            base.Awake();
            _videoPlayer = GetComponent<VideoPlayer>();
        }
    }
}
