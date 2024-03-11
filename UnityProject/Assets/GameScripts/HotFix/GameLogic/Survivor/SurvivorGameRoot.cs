using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public InputSystem _Input;
        public CharacterSystem _Character;
        public EnemyManager _Enemy;

        protected override void Awake()
        {
            _Input = AddManager<InputSystem>();
            _Character = AddManager<CharacterSystem>();
            _Enemy = AddManager<EnemyManager>();
            
            _Character.LoadCharacter("优衣");
            _Enemy.CreateEnemy();
        }

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
        }
    }
}