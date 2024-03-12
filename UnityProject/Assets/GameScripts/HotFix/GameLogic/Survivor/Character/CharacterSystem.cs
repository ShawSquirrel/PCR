using System;
using GameBase;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterSystem : GameBase.System, IRelease
    {
        private GameObject _character;
        private CharacterCtl _characterCtl;
        private FSM<Enum_ChracterState> _fsm;

        public Vector3 Pos => _character.transform.position;

        public override void Awake()
        {
            base.Awake();
        }

        public void LoadCharacter(string name)
        {
            _character = GameModule.Resource.LoadAsset<GameObject>(name);
            _character.name = name;
            _character.transform.SetParent(_TF);
            _character.AddComponent<PlayerColliderEvent>();
            _characterCtl = new CharacterCtl(_character);
            FSMInit();
        }

        private void FSMInit()
        {
            _fsm = new FSM<Enum_ChracterState>();
            _fsm.AddState(Enum_ChracterState.Walk, new CharacterWalkProcedure(_fsm, _characterCtl));
            _fsm.AddState(Enum_ChracterState.Idle, new CharacterIdleProcedure(_fsm, _characterCtl));
            _fsm.AddState(Enum_ChracterState.Attack, new CharacterAttackProcedure(_fsm, _characterCtl));

            _fsm.StartState(Enum_ChracterState.Walk);
            Utility.Unity.AddUpdateListener(_fsm.Update);
        }

        public void Release()
        {
            _characterCtl = null;
            GameObject.Destroy(_character);
            _character = null;
            Utility.Unity.RemoveUpdateListener(_fsm.Update);
            _fsm = null;
        }
    }
}