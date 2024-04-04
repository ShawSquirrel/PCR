using GameLogic.NewArchitecture.Core;

namespace GameLogic.NewArchitecture.Game.Main
{
    /// <summary>
    /// 开始游戏
    /// </summary>
    public class StartGameCommand : Command
    {
        public override void Run()
        {
            base.Run();
            MainRoot.Instance.GetModel<GameModel>().Bool_GameLaunching.Value = true;
        }
    }
}