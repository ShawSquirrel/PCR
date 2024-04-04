using System.ComponentModel;
using GameLogic.NewArchitecture.Core;
using GameLogic.NewArchitecture.Core.BindableValue;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{

    public class GameModel : Model
    {
        public BindableValue<bool> Bool_GameLaunching;

        public override void Awake()
        {
            base.Awake();
            Bool_GameLaunching = new BindableValue<bool>();
            Bool_GameLaunching.AddListen((b) =>
            {
                switch (b)
                {
                    case true:
                        GameEvent.Send(EventID.StartSurvivorGameID);
                        break;
                }
            });
        }
    }
}