using System.Collections.Generic;
using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyManager : GameBase.System
    {
        public List<EnemyController> _List_Enemy;
        public override void Init()
        {
            base.Init();
            _List_Enemy = new List<EnemyController>();
        }

        public void CreateEnemy()
        {
            GameObject prefab = GameModule.Resource.LoadAsset<GameObject>("Quad1");

            GameObject enemy = GameObject.Instantiate(prefab, _TF);
            enemy.name = "Enemy";

            enemy.AddComponent<EnemyController>();
            
            GameObject.Destroy(prefab);
        }
    }
}