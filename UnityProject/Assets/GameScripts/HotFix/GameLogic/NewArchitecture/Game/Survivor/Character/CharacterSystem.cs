using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterSystem : Core.System
    {
        private ACharacter _character;
        public override void Create()
        {
            base.Create();
            _character = new CharacterController();
        }

        public override void Init()
        {
            base.Init();
            _character.Init();
        }

        public override void Release()
        {
            base.Release();
            _character.Release();
            _character = null;
        }

        public override void Destroy()
        {
            base.Destroy();
            _character.Destroy();
        }
    }
}