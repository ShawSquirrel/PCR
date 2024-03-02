namespace GameLogic.Sokoban
{
    public class SokobanGameRoot : GameBase.GameRoot
    {
        public static SokobanGameRoot _Instance => _instance as SokobanGameRoot;
        public SokobanMapManager _Map => GetManager<SokobanMapManager>();
        public PlayerInputManager _Input => GetManager<PlayerInputManager>();
        public PlayerManager _Player => GetManager<PlayerManager>();
        public CameraManager _Camera => GetManager<CameraManager>();
        public SokobanLevelManager _Level => GetManager<SokobanLevelManager>();

        protected override void Awake()
        {
            base.Awake();
            AddManager<SokobanLevelManager>();
            AddManager<SokobanMapManager>();
            AddManager<PlayerInputManager>();
            AddManager<PlayerManager>();
            AddManager<CameraManager>();

        }

        public void OnReset()
        {
            _Map.OnReset();
            _Player.OnReset();
            _Input.OnReset();
            _Camera.OnReset();
            _Level.OnReset();
        }
        
        
        
    }
}