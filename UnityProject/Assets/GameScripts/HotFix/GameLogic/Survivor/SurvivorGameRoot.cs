using TEngine;
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
            
            _Character.LoadCharacter("佩可");
        }

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
            Utility.Unity.AddUpdateListener(Update);
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