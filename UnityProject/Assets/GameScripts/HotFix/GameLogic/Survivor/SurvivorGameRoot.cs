using System;
using Cysharp.Threading.Tasks;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public static SurvivorGameRoot Instance => Game._SurvivorGameRoot;

        public PlayerInputManager _Input;
        public CharacterManager _Character;
        public CameraManager _Camera;

        private  void Awake()
        {
            _Input = AddManager<PlayerInputManager>();
            _Character = AddManager<CharacterManager>();
            _Camera = AddManager<CameraManager>();
            
            
            
        }

        private void Start()
        {
            _Camera.Init();
            _Character.Init();
            _Camera.SetFollowAndLookAt(_Character.TFCharacter);
        }
    }
}