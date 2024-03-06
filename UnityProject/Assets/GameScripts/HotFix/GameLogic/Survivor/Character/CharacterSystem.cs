using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterData
    {
        public const float _MoveSpeed = 3f;
    }
    public class CharacterSystem : GameBase.System
    {
        private GameObject _character;
        private Rigidbody2D _rigidbody2D;
        private AnimComponent _animComponent;


        public override void Addlisten()
        {
            base.Addlisten();
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_Move, OnMove);
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_MoveStop, OnMove);
        }

        private void OnMove(Vector2 direct)
        {
            _rigidbody2D.velocity = direct * CharacterData._MoveSpeed;
        }

        public void LoadCharacter(string name)
        {
            _character      = GameModule.Resource.LoadAsset<GameObject>(name);
            _character.name = name;
            _character.transform.SetParent(_TF);
            _rigidbody2D   = _character.GetComponent<Rigidbody2D>();
            _animComponent = _character.GetComponentInChildren<AnimComponent>();
        }
    }
}