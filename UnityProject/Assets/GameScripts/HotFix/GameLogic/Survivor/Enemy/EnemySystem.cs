using System.Collections.Generic;
using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemySystem : GameBase.System, IRelease
    {
        public List<EnemyCtl> _List_Enemy;
        public Vector3 PlayerPos => Game._SurvivorGameRoot._Character.Pos;

        public override void Awake()
        {
            base.Init();
            _List_Enemy = new List<EnemyCtl>();
            
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

            enemyCtl.SetName("Enemy");
            enemyCtl.SetPos(PlayerPos + randomPosition);
            
            _List_Enemy.Add(enemyCtl);
        }

        public void Release()
        {
            foreach (EnemyCtl controller in _List_Enemy)
            {
                GameObject.Destroy(controller.Chracter);
            }

            _List_Enemy.Clear();
        }
    }
}