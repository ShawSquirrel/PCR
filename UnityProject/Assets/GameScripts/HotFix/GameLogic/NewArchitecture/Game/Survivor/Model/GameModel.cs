using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class GameModel : Model
    {
        public readonly BindableValue<TCharacterType> SelectCharacter = new BindableValue<TCharacterType>();

        public override void Awake()
        {
            base.Awake();
            SelectCharacter.Value = (TCharacterType)PlayerPrefsUtils.GetInt("SelectCharacter", 0);
        }
    }
}