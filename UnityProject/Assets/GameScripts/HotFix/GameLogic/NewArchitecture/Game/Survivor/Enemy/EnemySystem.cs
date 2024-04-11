using System;
using System.Collections.Generic;
using GameLogic.NewArchitecture.Core;
using GameLogic.Survivor;
using Utility = TEngine.Utility;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemySystem : Core.System
    {
        private Dictionary<IUnit, IEnemy> _dict_Enemy = new Dictionary<IUnit, IEnemy>();
        public override void Awake()
        {
            base.Awake();
            _dict_Enemy = new Dictionary<IUnit, IEnemy>();
        }

        public override void Init()
        {
            base.Init();
            Utility.Unity.AddFixedUpdateListener(FixedUpdate);
        }

        private void FixedUpdate()
        {
            
        }

        public void CreateEnemy(Enum_EnemyType enemyType)
        {
            IEnemy enemy = null;
            switch (enemyType)
            {
                case Enum_EnemyType.Normal:
                    enemy = new NormalEnemy();
                    break;
            }
            enemy.Init();
            _dict_Enemy[enemy.GetUnit()] = enemy;
        }

        public override void Release()
        {
            base.Release();
            Utility.Unity.RemoveFixedUpdateListener(FixedUpdate);
            foreach (var (key, value) in _dict_Enemy)
            {
                value.Destroy();
            }
            _dict_Enemy.Clear();
        }

        public override void Destroy()
        {
            base.Destroy();
            _dict_Enemy = null;
        }
        
        
    }
}