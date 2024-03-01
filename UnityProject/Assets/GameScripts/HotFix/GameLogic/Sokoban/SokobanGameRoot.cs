namespace GameLogic.Sokoban
{
    public class SokobanGameRoot : GameBase.GameRoot
    {
        public static SokobanGameRoot _Instance => _instance as SokobanGameRoot;
        public SokobanMapManager _Map => GetManager<SokobanMapManager>();
        public PlayerInputManager _Input => GetManager<PlayerInputManager>();
        public PlayerManager _Player => GetManager<PlayerManager>();
        public CameraManager _Camera => GetManager<CameraManager>();

        protected override void Awake()
        {
            base.Awake();
            AddManager<SokobanLevelManager>();
            // AddManager<SokobanMapManager>();
            // AddManager<PlayerInputManager>();
            // AddManager<PlayerManager>();
            // AddManager<CameraManager>();


            // _Player.LoadCharacter("优衣");
            // _Camera.SetFollowAndLookAt(_Player.Character.transform);
            //
        }
    }
}