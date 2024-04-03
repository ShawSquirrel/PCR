using System.Collections.Generic;
using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemySystem : GameBase.System, IRelease
    {
        private SurvivorGameRoot Root => Game._SurvivorGameRoot;
        private List<EnemyCtl> _list_Enemy;
        private Dictionary<GameObject, EnemyCtl> _dict_EnemyCtl;

        public override void Awake()
        {
            _list_Enemy = new List<EnemyCtl>();
            _dict_EnemyCtl = new Dictionary<GameObject, EnemyCtl>();
        }


        #region Start Release

        public void Start()
        {
        }

        public void Release()
        {
            foreach (EnemyCtl controller in _list_Enemy)
            {
                controller.Release();
                Object.Destroy(controller.Chracter);
            }

            _list_Enemy.Clear();
        }

        #endregion


        public EnemyCtl GetEnemyCtlByGameObject(GameObject obj)
        {
            EnemyCtl enemyCtl;
            if (_dict_EnemyCtl.TryGetValue(obj, out enemyCtl))
            {
                return enemyCtl;
            }

            Log.Error($"没有这个敌人 {obj.name}");
            return null;
        }

        public void DieEnemy(EnemyCtl ctl)
        {
            _list_Enemy.Remove(ctl);
            _dict_EnemyCtl.Remove(ctl.Chracter);
        }


        #region Create Enemy

        private float _lastGenTime = 0;

        public void CreateEnemy()
        {
            if (_lastGenTime > 5f)
            {
                CreateEnemy("镜华");
                _lastGenTime = 0;
            }

            _lastGenTime += Time.deltaTime;
        }

        public void CreateEnemy(string name)
        {
            // 生成随机角度
            float randomAngle = Random.Range(0f, 360f);

            // 将极坐标转换为笛卡尔坐标
            float x = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
            float y = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

            // 生成随机位置在内半径和外半径之间
            float randomRadius = Random.Range(5, 10);

            // 计算最终的位置
            Vector3 randomPosition = new Vector3(x, y, 0) * randomRadius;

            EnemyCtl enemyCtl = new EnemyCtl(name);

            Vector3 playerPos = Root.GetCharacterTransform().position;
            enemyCtl.SetName("Enemy");
            enemyCtl.SetPos(playerPos + randomPosition);
            enemyCtl.Chracter.transform.SetParent(_TF);

            _list_Enemy.Add(enemyCtl);
            _dict_EnemyCtl.Add(enemyCtl.Chracter, enemyCtl);
        }

        #endregion
    }
}