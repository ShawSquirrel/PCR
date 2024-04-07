using GameLogic.NewArchitecture.Core;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public enum GameType
    {
        Select,
        Survivor
    }

    public class GameModel : Model
    {
        public BindableValue<GameType> _GameType;

        public override void Awake()
        {
            base.Awake();
            _GameType = new BindableValue<GameType>();
            _GameType.AddListen((type) =>
            {
                switch (type)
                {
                    case GameType.Select:
                        GameEvent.Send(EventID.ReturnSelectGameID);
                        break;
                    case GameType.Survivor:
                        GameEvent.Send(EventID.SelectSurvivorGameID);
                        break;
                }
            });
        }
    }
}