using GameLogic.NewArchitecture.Core;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorRoot : Core.Game, ISingleton
    {
        public static SurvivorRoot Instance => SingletonGroup.GetSingleton<SurvivorRoot>();

        public void OnSingletonInit()
        {
        }


        public override void Awake()
        {
            base.Awake();
            InitUnit(null, "SurvivorRoot");
            AddSystem<SurvivorProcedureSystem>();
            
            
            
            Init();

        }

        public override void Init()
        {
            base.Init();
            GetSystem<SurvivorProcedureSystem>().Init();
        }
    }
}