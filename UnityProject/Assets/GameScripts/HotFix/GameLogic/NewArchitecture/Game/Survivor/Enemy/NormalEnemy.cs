namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class NormalEnemy : AEnemy
    {
        public override void Awake()
        {
            base.Awake();
            InitUnit("冰川镜华");
        }
    }
}