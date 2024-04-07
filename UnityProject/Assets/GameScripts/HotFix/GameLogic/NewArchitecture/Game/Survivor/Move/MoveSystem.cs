using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor.Move
{
    public class MoveSystem : Core.System
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            base.Init();
            Utility.Unity.AddFixedUpdateListener(FixedUpdate);
        }

        public override void Release()
        {
            base.Release();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void FixedUpdate()
        {
            Vector2 speed = SurvivorRoot.Instance.GetModel<GameModel>().CharacterSpeed.Value;
        }
        
    }
}