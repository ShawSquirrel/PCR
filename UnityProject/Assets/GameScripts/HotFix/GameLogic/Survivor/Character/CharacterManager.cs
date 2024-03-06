using System;
using GameBase;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterData
    {
        public const float _MoveSpeed = 3f;
    }

    public class CharacterManager : Manager
    {
        private GameObject _character;
        private Rigidbody2D _rigidbody2D;
        private AnimComponent _animComponent;
        private CharacterCtl _characterCtl;
        private FSM<Enum_ChracterState> _fsm;

        public Transform TFCharacter => _character.transform;
        public CharacterCtl CharacterCtl => _characterCtl;

        public override void Init()
        {
            AddFsm();
        }
        public override void Awake()
        {
            base.Awake();
            LoadCharacter("优衣");

        }

        public void AddFsm()
        {
            _fsm = new FSM<Enum_ChracterState>();
            _fsm.AddState(Enum_ChracterState.Walk, new CharacterWalkProcedure(_fsm, this));
            _fsm.AddState(Enum_ChracterState.Idle, new CharacterIdleProcedure(_fsm, this));
            _fsm.AddState(Enum_ChracterState.Attack, new CharacterAttackProcedure(_fsm, this));
            
            _fsm.StartState(Enum_ChracterState.Walk);
        }

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

        private void LoadCharacter(string name)
        {
            _character = GameModule.Resource.LoadAsset<GameObject>(name);
            _character.name = name;
            _character.transform.SetParent(_TF);
            _rigidbody2D = _character.GetComponent<Rigidbody2D>();
            _animComponent = _character.GetComponentInChildren<AnimComponent>();
            _characterCtl = _character.AddComponent<CharacterCtl>();
        }

        public void PlayAnim(EAnimState animState, bool isLoop = false, Action onComplete = null)
        {
            _animComponent.Play(animState, isLoop, onComplete);
        }
    }
}