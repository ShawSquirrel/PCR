using System;
using System.Collections.Generic;
using GameLogic.Survivor;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemySystem : Core.System
    {
        public List<IEnemy> _List_Enemy = new List<IEnemy>();
        public override void Awake()
        {
            base.Awake();
            _List_Enemy = new List<IEnemy>();
        }

        public override void Init()
        {
            base.Init();
            Utility.Unity.AddFixedUpdateListener(FixedUpdate);
        }

        private void FixedUpdate()
        {
            foreach (IEnemy enemy in _List_Enemy)
            {
                enemy.Move();
            }
        }

        public void CreateEnemy(Enum_EnemyType enemyType)
        {
            switch (enemyType)
            {
                case Enum_EnemyType.Normal:
                    _List_Enemy.Add(new NormalEnemy());
                    break;
            }
        }

        public override void Release()
        {
            base.Release();
            Utility.Unity.RemoveFixedUpdateListener(FixedUpdate);
            foreach (IEnemy enemy in _List_Enemy)
            {
                enemy.Destroy();
            }
            _List_Enemy.Clear();
        }

        public override void Destroy()
        {
            base.Destroy();
            _List_Enemy = null;
        }
        
        
    }
}