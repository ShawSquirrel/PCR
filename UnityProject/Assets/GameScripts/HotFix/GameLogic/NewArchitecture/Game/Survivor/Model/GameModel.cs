using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class GameModel : Model
    {
        public readonly BindableValue<TCharacterID> SelectCharacter = new BindableValue<TCharacterID>();

        public override void Awake()
        {
            base.Awake();
            SelectCharacter.Value = (TCharacterID)PlayerPrefsUtils.GetInt("SelectCharacter", 0);
        }
    }
}