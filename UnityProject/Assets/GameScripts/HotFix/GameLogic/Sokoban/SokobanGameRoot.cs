using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanGameRoot : GameBase.GameRoot
    {
        public static SokobanGameRoot _Instance => Game._SokobanGameRoot;
        public SokobanMapSystem _Map => GetManager<SokobanMapSystem>();
        public PlayerInputSystem _Input => GetManager<PlayerInputSystem>();
        public PlayerSystem _Player => GetManager<PlayerSystem>();
        public CameraSystem _Camera => GetManager<CameraSystem>();
        public SokobanLevelSystem _Level => GetManager<SokobanLevelSystem>();
        public MapMakeSystem _Make => GetManager<MapMakeSystem>();

        protected override void OnInit()
        {
            AddManager<SokobanLevelSystem>();
            AddManager<SokobanMapSystem>();
            AddManager<PlayerInputSystem>();
            AddManager<PlayerSystem>();
            AddManager<CameraSystem>();
            AddManager<MapMakeSystem>();

        }

        public void OnReset()
        {
            _Map.OnReset();
            _Player.OnReset();
            _Input.OnReset();
            _Camera.OnReset();
            _Level.OnReset();
            _Make.OnReset();
        }


        public SokobanGameRoot(GameObject obj) : base(obj)
        {
        }
    }
}