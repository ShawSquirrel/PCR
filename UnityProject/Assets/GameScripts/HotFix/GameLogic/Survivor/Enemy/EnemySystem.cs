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
            float x = Random.Range(50, 100) * Random.Range(-1, 1) > 0 ? 1 : -1;
            float y = Random.Range(50, 100) * Random.Range(-1, 1) > 0 ? 1 : -1;
            EnemyCtl enemyCtl = new EnemyCtl(name);

            enemyCtl.SetName("Enemy");
            enemyCtl.SetPos(PlayerPos + new Vector3(x, y));
            
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