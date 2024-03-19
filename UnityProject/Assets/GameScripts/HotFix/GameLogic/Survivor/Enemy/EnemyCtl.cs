using System;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyCtl : EntityCtl
    {
        protected FSM<Enum_EnemyState> _fsm;
        public EnemyCtl(string characterName) : base(characterName)
        {
            FSMInit();
            _chracter.layer = LayerMask.NameToLayer("Enemy");
            _body.layer = LayerMask.NameToLayer("Enemy");
        }

        protected override void FSMInit()
        {
            base.FSMInit();
            _fsm = new FSM<Enum_EnemyState>();
            _fsm.AddState(Enum_EnemyState.Walk, new EnemyWalkProcedure(_fsm, this));
            _fsm.AddState(Enum_EnemyState.Idle, new EnemyIdleProcedure(_fsm, this));
            _fsm.AddState(Enum_EnemyState.Damage, new EnemyDamageProcedure(_fsm, this));
            _fsm.AddState(Enum_EnemyState.Die, new EnemyDieProcedure(_fsm, this));
            
            _fsm.StartState(Enum_EnemyState.Walk);
        }

        protected override void Update()
        {
            Vector3 vector3 = (Game._SurvivorGameRoot._Character.Pos - _chracter.transform.position).normalized;
            SetTowards(vector3);
            _fsm.Update();
        }

        public override void Damage(float value)
        {
            base.Damage(value);
            _EntityBaseData._HP -= value;
        }

        public bool HpDetect()
        {
            if (_EntityBaseData._HP < 0)
            {
                return false;
            }

            return true;
        }

        public override void Die()
        {
            base.Die();
            Game._SurvivorGameRoot._Enemy.DieEnemy(this);
            _EntityBaseData = null;
            GameObject.Destroy(_chracter);
        }
        
    }
}