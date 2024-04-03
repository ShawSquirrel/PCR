using System;
using GameBase;
using GameConfig;
using TEngine;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameLogic.Survivor
{
    public class CharacterSystem : GameBase.System
    {
        private GameObject _character;
        private CharacterCtl _characterCtl;
        private FSM<Enum_ChracterState> _fsm;

        public Transform TFCharacter => _character.transform;
        public CharacterCtl CharacterCtl => _characterCtl;

        public void LoadCharacter(string name)
        {
            _characterCtl   = new CharacterCtl(name);
            _character      = _characterCtl.Chracter;
            _character.name = name;
            _character.transform.SetParent(_TF);
            _character.AddComponent<PlayerColliderEvent>();
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

        public override void Release()
        {
            _characterCtl = null;
            Object.Destroy(_character);
            _character = null;
            Utility.Unity.RemoveUpdateListener(_fsm.Update);
            _fsm = null;
        }

        public Transform GetCharacterTransform()
        {
            if (_isRelease)
            {
                return _character.transform;
            }
            return null;
        }
    }
}