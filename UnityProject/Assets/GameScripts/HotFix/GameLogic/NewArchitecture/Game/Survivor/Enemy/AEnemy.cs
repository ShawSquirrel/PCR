using System;
using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;
using Utility = TEngine.Utility;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public abstract class AEnemy : IEnemy
    {
        public Unit _Unit;
        public FSM<Enum_EnemyState> _FSM = new FSM<Enum_EnemyState>();
        public Rigidbody2D _Rigidbody2D;
        public AnimComponent _Anim;
        public Transform _Body;
        public bool _IsDie = false;

        public AEnemy()
        {
            Awake();
            InitFSM();
        }

        public virtual void InitUnit(string prefabName)
        {
            GameObject obj = GameModule.Resource.LoadAsset<GameObject>(prefabName);
            _Unit = new Unit(obj);
            _Unit.SetName(prefabName);
            _Rigidbody2D = _Unit.GetComponentInChildren<Rigidbody2D>();
            _Anim = _Unit.GetComponentInChildren<AnimComponent>();
            _Body = _Unit.Find("Body");

        }

        public virtual void InitFSM()
        {
            _FSM.AddState(Enum_EnemyState.Walk, new EnemyWalkProcedure(_FSM, this));
            _FSM.AddState(Enum_EnemyState.Die, new EnemyDieProcedure(_FSM, this));
            _FSM.AddState(Enum_EnemyState.Damage, new EnemyDamageProcedure(_FSM, this));
        }

        public virtual void Move()
        {
            if (_IsDie == true) return;
            _Rigidbody2D.velocity = GetTowards() * 1;
        }

        public virtual void Atk()
        {
        }

        public virtual void Damage()
        {
        }

        public virtual void Init()
        {
           _FSM.StartState(Enum_EnemyState.Walk);
           Utility.Unity.AddFixedUpdateListener(_FSM.FixedUpdate);
        }

        public virtual void Release()
        {
            Utility.Unity.RemoveFixedUpdateListener(_FSM.FixedUpdate);
        }

        public virtual void Awake()
        {
        }

        public virtual void Destroy()
        {
            if (_Unit != null)
            {
                _Unit.Destroy();
                _Unit = null;
            }
        }

        public Vector3 GetTowards()
        {
            Vector3 pos = SurvivorRoot.Instance.GetModel<CharacterModel>()._Unit.Value.LocalPosition;
            Vector3 distance = pos - _Unit.Position;
            return distance.magnitude > 0.5f ? distance.normalized : Vector3.zero;
        }

        public void ResetSpeed()
        {
            _Rigidbody2D.velocity = Vector2.zero;
        }

        public void PlayAnim(EAnimState state, bool isLoop, Action onComplete = null)
        {
            _Anim.Play(state, isLoop, onComplete);
        }

        public void SetColliderBoxEnable(bool isEnable)
        {
        }

        public void Die()
        {
        }

        public void UpdateTowards()
        {
            Vector3 towards = GetTowards();
            switch (towards.x)
            {
                case > 0:
                    SetFlipX(false);
                    break;
                case < 0:
                    SetFlipX(true);
                    break;
            }
        }
        
        protected virtual void SetFlipX(bool isLeft)
        {
            Vector3 scale = _Body.localScale;
            if (scale.x > 0 && isLeft)
            {
                scale.Set(-scale.x, scale.y, scale.z);
            }
            else if (scale.x < 0 && !isLeft)
            {
                scale.Set(-scale.x, scale.y, scale.z);
            }
            else
            {
                return;
            }

            _Body.localScale = scale;
        }

    }
}