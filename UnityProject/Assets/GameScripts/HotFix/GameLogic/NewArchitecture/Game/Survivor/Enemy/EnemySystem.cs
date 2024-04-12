using System.Collections.Generic;
using GameConfig;
using GameLogic.NewArchitecture.Core;
using Utility = TEngine.Utility;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemySystem : Core.System
    {
        private Dictionary<IUnit, IEnemy> _dict_Enemy = new Dictionary<IUnit, IEnemy>();
        private Dictionary<IEnemy, EnemyData> _dict_EnemyData = new Dictionary<IEnemy, EnemyData>();
        public override void Awake()
        {
            base.Awake();
            _dict_Enemy = new Dictionary<IUnit, IEnemy>();
            _dict_EnemyData = new Dictionary<IEnemy, EnemyData>();
        }

        public override void Init()
        {
            base.Init();
            Utility.Unity.AddFixedUpdateListener(FixedUpdate);
        }

        private void FixedUpdate()
        {
            
        }

        public void CreateEnemy(TCharacterType enemyType)
        {
            IEnemy enemy = null;
            switch (enemyType)
            {
                case TCharacterType.BingChuanJingHua:
                    enemy = new BingChuanJingHuaEnemy();
                    break;
            }

            if (enemy == null)
            {
                MLog.Critical($"{GetType().Name} 敌人没有创建成功");
                return;
            }
            enemy.Init();
            _dict_Enemy[enemy.GetUnit()] = enemy;
            _dict_EnemyData[enemy] = SurvivorConfig.GetEnemyByType(enemyType).ToEnemyData();
        }

        public void DieEnemy(IEnemy enemy)
        {
            _dict_Enemy.Remove(enemy.GetUnit());
            _dict_EnemyData.Remove(enemy);
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
            _dict_EnemyData.Clear();
        }

        public override void Destroy()
        {
            base.Destroy();
            _dict_Enemy = null;
            _dict_EnemyData = null;
        }

        public IEnemy GetEnemyByUnit(IUnit unit)
        {
            return _dict_Enemy.GetValueOrDefault(unit);
        }
        public EnemyData GetEnemyDataByUnit(IEnemy enemy)
        {
            return _dict_EnemyData.GetValueOrDefault(enemy);
        }
    }
}