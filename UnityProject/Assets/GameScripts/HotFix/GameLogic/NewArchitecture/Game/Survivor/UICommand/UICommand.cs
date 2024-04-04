using GameLogic.NewArchitecture.Core;
using GameLogic.NewArchitecture.Game.Main;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    /// <summary>
    /// 返回选择游戏界面
    /// </summary>
    public class ReturnSelectCommand : Command
    {
        public override void Run()
        {
            base.Run();
            MainRoot.Instance.GetModel<GameModel>()._GameType.Value = GameType.Select;
        }
    }
}