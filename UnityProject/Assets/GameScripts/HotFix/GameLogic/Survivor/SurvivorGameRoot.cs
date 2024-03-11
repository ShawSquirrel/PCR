using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public InputSystem _Input;
        public CharacterSystem _Character;
        public EnemySystem _Enemy;
        public UIEvent _UIEvent;

        protected override void Init()
        {
            base.Init();
            Utility.Unity.AddUpdateListener(Update);
            GameEvent.AddEventListener(EventID_Survivor.Survivor_Release, Release);
            _Input = AddManager<InputSystem>();
            _Character = AddManager<CharacterSystem>();
            _Enemy = AddManager<EnemySystem>();

            _UIEvent = new UIEvent();
            _UIEvent.AddListen();
            
            _Character.LoadCharacter("佩可");
        }

        protected override void Release()
        {
            base.Release();
            _Input.Release();
            _Character.Release();
            _Enemy.Release();
        }

        protected override void Destroy()
        {
            base.Destroy();
            _UIEvent.RemoveListen();
            _UIEvent = null;
        }

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
        }

        private float lastGenTime = 0;
        private void Update()
        {
            if (lastGenTime > 5f)
            {
                _Enemy.CreateEnemy();
                lastGenTime = 0;
            }

            lastGenTime += Time.deltaTime;
        }
    }
}