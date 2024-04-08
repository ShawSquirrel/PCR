using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterMode : Model
    {
        public BindableValue<Unit> _Unit = new BindableValue<Unit>();
        public BindableValue<CharacterComponent> _CharacterComponent = new BindableValue<CharacterComponent>();
        public override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            base.Init();
            var id = SurvivorRoot.Instance.GetModel<GameModel>().SelectCharacter.Value;
            var sCharacter = ConfigSystem.Instance.Tables.SCharacter.DataList.Find(a => a.CharacterType == id);
            GameObject obj = GameModule.Resource.LoadAsset<GameObject>(sCharacter.Name);
            _Unit.Value = new Unit(obj, null, sCharacter.Name);

            _CharacterComponent.Value = new CharacterComponent
            {
                _Rigidbody2D = _Unit.Value.GetComponentInChildren<Rigidbody2D>(),
                _Anim = _Unit.Value.GetComponentInChildren<AnimComponent>(),
            };
        }

        public override void Release()
        {
            base.Release();
            if (_Unit.Value == null) return;
            _Unit.Value.Destroy();
            _Unit.SetNull();
            _CharacterComponent.SetNull();
        }
    }

    public class CharacterComponent
    {
        public Rigidbody2D _Rigidbody2D;
        public AnimComponent _Anim;
    }
}