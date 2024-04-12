namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class BingChuanJingHuaEnemy : AEnemy
    {
        public override void Awake()
        {
            base.Awake();
            InitUnit("冰川镜华");
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);
            
        }
    }
}