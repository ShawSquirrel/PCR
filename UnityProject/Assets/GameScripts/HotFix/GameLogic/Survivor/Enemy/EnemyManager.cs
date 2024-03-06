using System.Collections.Generic;
using GameBase;

namespace GameLogic.Survivor
{
    public class EnemyManager : Manager
    {
        public List<EnemyController> _List_Enemy;
        public override void Init()
        {
            base.Init();
            _List_Enemy = new List<EnemyController>();
        }

        public void CreateEnemyManager(Enum_EnemyType type)
        {
            
        }
    }
}