using GameConfig;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public static class EnemyDataHelper
    {
        public static EnemyData ToEnemyData(this SEnemy self)
        {
            return new EnemyData
            {
                _MaxHp = (int)self.Hp,
                _CurHp = (int)self.Hp,
                _Speed = self.Speed,
                _Atk = self.Atk
            };
        }
    }
}