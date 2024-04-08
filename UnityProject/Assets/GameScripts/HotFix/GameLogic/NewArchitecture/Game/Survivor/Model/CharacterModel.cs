using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterModel : Model
    {
        public BindableValue<Unit> _Unit = new BindableValue<Unit>();
        public BindableValue<CharacterComponent> _CharacterComponent = new BindableValue<CharacterComponent>();
        public readonly BindableValue<Vector2> _CharacterSpeed = new BindableValue<Vector2>();
        public readonly BindableValue<bool> _CanMove = new BindableValue<bool>();

        public override void Awake()
        {
            base.Awake();
            _CharacterSpeed.SetValueWithoutCallback(Vector2.zero);
        }

        public override void Init()
        {
            base.Init();
            var id = SurvivorRoot.Instance.GetModel<GameModel>().SelectCharacter.Value;
            var sCharacter = ConfigSystem.Instance.Tables.SCharacter.DataList.Find(a => a.CharacterType == id);
            GameObject obj = GameModule.Resource.LoadAsset<GameObject>(sCharacter.Name);
            _Unit.Value = new Unit(obj, null, sCharacter.Name);

            _CharacterComponent.Value = new CharacterComponent();
            _CharacterComponent.Value._Rigidbody2D = _Unit.Value.GetComponentInChildren<Rigidbody2D>();
            _CharacterComponent.Value._Anim = _Unit.Value.GetComponentInChildren<AnimComponent>();
            _CharacterComponent.Value._Body = new Unit(_Unit.Value._TF.Find("Body").gameObject);
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
        public Unit _Body;
    }
}