using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class MoveSystem : Core.System
    {
        private Rigidbody2D _rigidbody2D;

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
            Utility.Unity.RemoveFixedUpdateListener(FixedUpdate);
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void FixedUpdate()
        {
            Vector2 speed = SurvivorRoot.Instance.GetModel<GameModel>().CharacterSpeed.Value;
            _rigidbody2D.velocity = speed;
        }
    }
}