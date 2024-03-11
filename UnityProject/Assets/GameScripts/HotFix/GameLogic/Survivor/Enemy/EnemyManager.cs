using System.Collections.Generic;
using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyManager : GameBase.System
    {
        public List<EnemyController> _List_Enemy;
        public Vector3 PlayerPos => Game._SurvivorGameRoot._Character.Pos;

        public override void Init()
        {
            base.Init();
            _List_Enemy = new List<EnemyController>();
        }

        public void CreateEnemy()
        {
            float x = Random.Range(50, 100) * Random.Range(-1, 1) > 0 ? 1 : -1;
            float y = Random.Range(50, 100) * Random.Range(-1, 1) > 0 ? 1 : -1;
            
            GameObject prefab = GameModule.Resource.LoadAsset<GameObject>("Quad1");

            GameObject enemy = GameObject.Instantiate(prefab, _TF);
            enemy.name               = "Enemy";
            enemy.transform.position = PlayerPos + new Vector3(x, y);

            enemy.AddComponent<EnemyController>();
            
            GameObject.Destroy(prefab);
        }
    }
}