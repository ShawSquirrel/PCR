using System;
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
        private GameObject _body;
        
        
        public CharacterData CharacterData => _characterData;
        public CharacterCtl(GameObject character)
        {
            AddListen();

            _chracter      = character;
            _characterData = new CharacterData();
            _animComponent = character.GetComponentInChildren<AnimComponent>();
            _rigidbody2D   = character.GetComponent<Rigidbody2D>();
            _body          = character.transform.Find("Body").gameObject;
            
            Utility.Unity.AddUpdateListener(Update);
        }

        private void AddListen()
        {
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_Move, OnMove);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_MoveStop, OnMove);
            GameEvent.AddEventListener<IDamage>(EventID_Survivor.Survivor_Damage, OnDamage);
        }

        private void Update()
        {
            GameEvent.Send(UIEventID_Survivor.SetBlood, _characterData._HP / 100);
        }

        private void OnDamage(IDamage damage)
        {
            if (_characterData._HP <= 0)
            {
                return;
            }
            _characterData._HP -= damage.GetAtk();
            if (_characterData._HP <= 0)
            {
                GameEvent.Send(EventID_Survivor.Survivor_Die);
                Time.timeScale = 0;
            }
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

    }
}