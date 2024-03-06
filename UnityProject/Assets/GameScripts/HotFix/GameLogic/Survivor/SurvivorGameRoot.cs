using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public InputSystem _Input;
        public CharacterSystem _Character;

        protected override void Awake()
        {
            _Input = AddManager<InputSystem>();
            _Character = AddManager<CharacterSystem>();
            
            
            _Character.LoadCharacter("优衣");
        }

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
        }
    }
}