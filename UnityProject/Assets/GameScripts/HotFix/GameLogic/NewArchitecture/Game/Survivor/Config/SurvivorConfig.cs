using GameConfig;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public static class SurvivorConfig
    {
        static SurvivorConfig()
        {
            
        }

        public static SCharacter GetCharacterByType(TCharacterType type)
        {
            SCharacter character = ConfigSystem.Instance.Tables.TCharacter.DataList.Find(a => a.CharacterType == type);
            return character;
        }
        public static SEnemy GetEnemyByType(TCharacterType type)
        {
            SEnemy enemy = ConfigSystem.Instance.Tables.TEnemy.DataList.Find(a => a.CharacterType == type);
            return enemy;
        }
    }
}