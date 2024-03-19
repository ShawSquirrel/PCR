using System;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EntityCtl : IMove, IUpdateTowards, IDamage, IAtk, ISpeed, IHP, IDie
    {
        protected AnimComponent _animComponent;
        protected Rigidbody2D _rigidbody2D;
        protected EntityBaseData _EntityBaseData;
        protected GameObject _chracter;
        protected GameObject _body;

        protected Vector2 _willApplyTowards;
        protected Vector2 _curTowards;


        public EntityBaseData EntityBaseData => _EntityBaseData;
        public GameObject Chracter => _chracter;
        public Vector2 CurTowards => _curTowards;

        public virtual void SetName(string name) => _chracter.name = name;
        public virtual void SetPos(Vector3 pos) => _chracter.transform.localPosition = pos;
        protected virtual void SetTowards(Vector2 direct) => _willApplyTowards = direct;

        public EntityCtl(string characterName)
        {
            AddListen();

            GameObject character = GameModule.Resource.LoadAsset<GameObject>(characterName);

            _EntityBaseData = new EntityBaseData(characterName);
            _chracter = character;
            _animComponent = character.GetComponentInChildren<AnimComponent>();
            _rigidbody2D = character.GetComponent<Rigidbody2D>();
            _body = character.transform.Find("Body").gameObject;

            Utility.Unity.AddUpdateListener(Update);
        }

        protected virtual void AddListen()
        {
        }

        protected virtual void Update()
        {
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="state"></param>
        /// <param name="isloop"></param>
        /// <param name="onComplete"></param>
        public virtual void PlayAnim(EAnimState state, bool isloop = false, Action onComplete = null)
        {
            _animComponent.Play(state, isloop, onComplete);
        }


        /// <summary>
        /// 移动
        /// </summary>
        public virtual void Move()
        {
            _rigidbody2D.velocity = _curTowards * _EntityBaseData._Speed;
        }

        /// <summary>
        /// 更新朝向
        /// </summary>
        public virtual void UpdateTowards()
        {
            _curTowards = _willApplyTowards;
            switch (_curTowards.x)
            {
                case > 0:
                    SetFlipX(false);
                    break;
                case < 0:
                    SetFlipX(true);
                    break;
            }
        }

        /// <summary>
        /// 设置是否镜像
        /// </summary>
        /// <param name="isLeft"></param>
        protected virtual void SetFlipX(bool isLeft)
        {
            Vector3 scale = _body.transform.localScale;
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

            _body.transform.localScale = scale;
        }

        protected virtual void FSMInit()
        {
        }

        public virtual void Damage(float value)
        {
            
        }

        public virtual float GetAtk()
        {
            return 0;
        }

        public virtual float GetSpeed()
        {
            return 0;
        }

        public virtual float GetHP()
        {
            return 0;
        }

        public virtual void Die()
        {
            Utility.Unity.RemoveUpdateListener(Update);
        }

        public virtual void ResetSpeed()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}