using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public abstract class AEnemy : IEnemy
    {
        public Unit _Unit;
        public Rigidbody2D _Rigidbody2D;
        

        public AEnemy()
        {
            Awake();
        }

        public void InitUnit(string prefabName)
        {
            GameObject obj = GameModule.Resource.LoadAsset<GameObject>(prefabName);
            _Unit = new Unit(obj);
            _Unit.SetName(prefabName);
            _Rigidbody2D = _Unit.GetComponentInChildren<Rigidbody2D>();
        }

        public virtual void Move()
        {
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
        }

        public virtual void Release()
        {
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
            return (pos - _Unit.Position).normalized;
        }
    }
}