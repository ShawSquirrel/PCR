using System;
using Cysharp.Threading.Tasks;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public static SurvivorGameRoot Instance => Game._SurvivorGameRoot;

        public PlayerInputManager _Input;
        public CharacterManager _Character;

        private  void Awake()
        {
            _Input = AddManager<PlayerInputManager>();
            _Character = AddManager<CharacterManager>();
            
            
            _Character.LoadCharacter("优衣");
        }
    }
}