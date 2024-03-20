using System;
using Cysharp.Threading.Tasks;
using TEngine;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace GameLogic.Survivor
{
    public class EnemyCtl : EntityCtl
    {
        protected FSM<Enum_EnemyState> _fsm;
        private bool _bool_IsDamaged;
        public bool Bool_IsDamaged => _bool_IsDamaged;

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
            _bool_IsDamaged = true;

            DamageText(value.ToString());
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
            Object.Destroy(_chracter);
        }

        public void ResetDamageState()
        {
            _bool_IsDamaged = false;
        }

        public void SetColliderBoxEnable(bool isEnable)
        {
            _boxCollider.enabled   = isEnable;
            _rigidbody2D.simulated = isEnable;
        }

        public async void DamageText(string text)
        {
            GameObject damageText = GameModule.Resource.LoadAsset<GameObject>("DamageText");
            damageText.transform.position = _body.transform.position + new Vector3(0, 0);
            TMP_Text tmPro = damageText.GetComponent<TMP_Text>();
            tmPro.text = text;
            await UniTask.WaitForSeconds(2);
            GameObject.Destroy(damageText);
        }

        public override float GetAtk()
        {
            return 50;
        }
    }
}