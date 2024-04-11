using GameConfig;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public static class SurvivorConfig
    {
        static SurvivorConfig()
        {
            
        }

        public static SCharacter GetCharacterById(TCharacterType type)
        {
            SCharacter character = ConfigSystem.Instance.Tables.TCharacter.DataList.Find(a => a.CharacterType == type);
            return character;
        }
    }
}