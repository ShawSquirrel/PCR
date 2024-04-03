using GameBase;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorRoot : Core.Game, ISingleton
    {
        public static SurvivorRoot Instance => SingletonGroup.GetSingleton<SurvivorRoot>();
        public void OnSingletonInit()
        {
            Awake();
        }

        public override void Awake()
        {
            InitUnit(null, "SurvivorRoot");
        }
        
    }
}