using System;
using Cysharp.Threading.Tasks;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public static SurvivorGameRoot Instance => Game._SurvivorGameRoot;

        private  void Awake()
        {
            AddManager<PlayerMoveManager>();
            
        }
    }
}