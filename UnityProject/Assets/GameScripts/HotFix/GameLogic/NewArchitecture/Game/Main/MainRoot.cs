using GameLogic.NewArchitecture.Core;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Main
{
    public class MainRoot : Core.Game, ISingleton
    {
        public static MainRoot Instance => SingletonGroup.GetSingleton<MainRoot>();


        public void OnSingletonInit()
        {
        }

        public override void Awake()
        {
            base.Awake();
            InitUnit(null, "Root");

            AddModel<GameModel>();
            AddSystem<ProcedureSystem>();
            
            Init();
        }

        public override void Init()
        {
            base.Init();
            GetSystem<ProcedureSystem>().Init();
        }
    }
}