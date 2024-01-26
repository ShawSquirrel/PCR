namespace GameLogic
{
    public enum RoundState
    {
        Friendly,
        Enemy
    }
    public class RoundManager : Entity
    {
        public int _RoundCount { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            LevelManager.Instance._RoundManager = this;

            _TF.SetParent(LevelManager.Instance._Root);
            _RoundCount = 0;
        }

        public void AddRound()
        {
            _RoundCount++;
        }
        
        
        
    }
}