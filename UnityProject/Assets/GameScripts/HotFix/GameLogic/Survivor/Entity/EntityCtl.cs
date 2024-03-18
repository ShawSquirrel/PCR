﻿using System;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EntityCtl : IMove, IUpdateTowards
    {
        protected AnimComponent _animComponent;
        protected Rigidbody2D _rigidbody2D;
        protected EntityData _entityData;
        protected GameObject _chracter;
        protected GameObject _body;


        public EntityData EntityData => _entityData;
        public GameObject Chracter => _chracter;

        public virtual void SetName(string name) => _chracter.name = name;
        public virtual void SetPos(Vector3 pos) => _chracter.transform.localPosition = pos;

        public EntityCtl(string characterName)
        {
            AddListen();

            GameObject character = GameModule.Resource.LoadAsset<GameObject>(characterName);
            
            _entityData = new EntityData();
            _chracter      = character;
            _animComponent = character.GetComponentInChildren<AnimComponent>();
            _rigidbody2D   = character.GetComponent<Rigidbody2D>();
            _body          = character.transform.Find("Body").gameObject;

            Utility.Unity.AddUpdateListener(Update);
        }

        protected virtual void AddListen()
        {
            
        }

        protected virtual void Update()
        {
            
        }

        /// <summary>
        /// 受伤
        /// </summary>
        /// <param name="damage"></param>
        protected virtual void OnDamage(IDamage damage)
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


        protected virtual void OnMove(Vector2 direct)
        {
            _entityData._Towards = direct;
        }


        /// <summary>
        /// 移动
        /// </summary>
        public virtual void Move()
        {
            _rigidbody2D.velocity = _entityData._Towards * _entityData._MoveSpeed;
        }

        /// <summary>
        /// 更新朝向
        /// </summary>
        public virtual void UpdateTowards()
        {
            if (_entityData._Towards.x > 0)
            {
                SetFlipX(false);
            }
            else if (_entityData._Towards.x < 0)
            {
                SetFlipX(true);
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
    }
}