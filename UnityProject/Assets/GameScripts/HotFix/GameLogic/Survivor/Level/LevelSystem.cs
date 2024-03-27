namespace GameLogic.Survivor
{
    public class LevelSystem : GameBase.System
    {
        #region Property

        private const int BaseLevelEXP = 10;
        private int _curLevelEXP;

        public int CurLevelExp
        {
            get => _curLevelEXP;
            set => _curLevelEXP = value;
        }


        private int _level;

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        private int _levelExpMax;

        public int LevelExpMax
        {
            get => _levelExpMax;
            set => _levelExpMax = value;
        }

        #endregion

        public void LevelUp()
        {
            _level++;
            _curLevelEXP = 0;
            _levelExpMax = BaseLevelEXP * _level;
        }

        #region Start Release

        public void Start()
        {
            AddListen();
            _curLevelEXP = 0;
            _level = 1;
            _levelExpMax = 10;
        }

        public void Release()
        {
            RemoveListen();
        }

        #endregion

        #region Listen

        private void AddListen()
        {
        }


        private void RemoveListen()
        {
        }

        #endregion
    }
}