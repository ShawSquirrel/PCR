﻿using System;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    /// <summary>
    /// 人物状态机，人物移动
    /// </summary>
    public class CharacterCtl
    {
        private AnimComponent _animComponent;
        private Rigidbody2D _rigidbody2D;
        private CharacterData _characterData;
        private GameObject _chracter;
        
        
        public CharacterData CharacterData => _characterData;
        public CharacterCtl(GameObject character)
        {
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_Move, OnMove);
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_MoveStop, OnMove);

            _chracter      = character;
            _characterData = new CharacterData();
            _animComponent = character.GetComponentInChildren<AnimComponent>();
            _rigidbody2D   = character.GetComponent<Rigidbody2D>();
            
            
        }

        public void PlayAnim(EAnimState state, bool isloop = false, Action onComplete = null)
        {
            _animComponent.Play(state, isloop, onComplete);
        }
        
        private void OnMove(Vector2 direct)
        {
            _characterData._Towards = direct;
        }

        public void Move()
        {
            _rigidbody2D.velocity = _characterData._Towards * _characterData._MoveSpeed;
            UpdateTowards();
        }

        public void UpdateTowards()
        {
            if (_characterData._Towards.x > 0)
            {
                SetFlipX(false);
            }
            else if (_characterData._Towards.x < 0)
            {
                SetFlipX(true);
            }
        }

        private void SetFlipX(bool isLeft)
        {
            Vector3 scale = _chracter.transform.localScale;
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

            _chracter.transform.localScale = scale;
        }
        
    }
}