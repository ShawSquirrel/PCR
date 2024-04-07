using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class GameModel : Model
    {
        public BindableValue<TCharacterID> SelectCharacter;

        public override void Awake()
        {
            base.Awake();
            SelectCharacter = new BindableValue<TCharacterID>();
            SelectCharacter.Value = (TCharacterID)PlayerPrefsUtils.GetInt("SelectCharacter", 0);
        }
    }
}