using System.Collections.Generic;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class BingChuanJingHuaEnemyController : AEnemy
    {
        public override void Create()
        {
            base.Create();
            InitUnit("冰川镜华");
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);
            
        }
    }
}