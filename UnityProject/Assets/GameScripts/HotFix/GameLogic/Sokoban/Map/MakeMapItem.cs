using System;
using Lean.Common;
using Lean.Touch;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class MakeMapItem : MonoBehaviour
    {
        private Enum_MaptemType _type;
        public Enum_MaptemType Type
        {
            get => _type;
            set
            {
                _type = value;
                UpdateState();
            }
        }


        public SpriteRenderer _Sprite;
        public SpriteRenderer _Mark;
        public SpriteRenderer _PlayerHead;
        public LeanSelectableByFinger _Selectable;

        

        private void Awake()
        {
            Type   = Enum_MaptemType.Empty;
            BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
            _Selectable         = gameObject.AddComponent<LeanSelectableByFinger>();
            _Sprite             = GetComponent<SpriteRenderer>();
            _Mark               = transform.GetChild(0).GetComponent<SpriteRenderer>();
            _PlayerHead         = transform.GetChild(1).GetComponent<SpriteRenderer>();
            _PlayerHead.enabled = false;
            _Mark.enabled       = false;

            AddListen();
        }

        public void AddListen()
        {
            _Selectable.OnSelected.AddListener(OnSelected);
        }

        private void OnSelected(LeanSelect arg0)
        {
            // GameEvent.Send(SokobanEvent.Sokoban_MakeMapClickItem, this);
        }


        private void OnMouseEnter()
        {
            _Mark.enabled = true;
        }
        private void OnMouseExit()
        {
            _Mark.enabled = false;
        }
        
        public void UpdateState()
        {
            if (_Sprite == null) return;
            // _TextMesh.text = $"{(int)_type}";
            _Sprite.sprite      = SokobanGameRoot._Instance._Map.GetSprite(_type);
            _Sprite.size        = Vector2.one;
            _PlayerHead.enabled = false;
            switch (_type)
            {
                case (Enum_MaptemType)0: // 空
                    _Sprite.color = Color.clear;
                    break;
                case (Enum_MaptemType)1: // 墙
                    _Sprite.color = Color.white;
                    break;
                case (Enum_MaptemType)2: // 空地
                    _Sprite.color = Color.gray;
                    break;
                case (Enum_MaptemType)4: // 目标位置
                    _Sprite.color = Color.white;
                    break;
                case (Enum_MaptemType)10: // 箱子 | 空地
                    _Sprite.color = Color.white;
                    break;
                case (Enum_MaptemType)12: // 箱子 | 目标位置
                    _Sprite.color = Color.white;
                    break;
                case (Enum_MaptemType)18: // 玩家 | 空地
                    _Sprite.color       = Color.white;
                    _PlayerHead.enabled = true;
                    break;
                case (Enum_MaptemType)20: // 玩家 | 目标位置
                    _Sprite.color       = Color.white;
                    _PlayerHead.enabled = true;
                    break;
                
                case Enum_MaptemType.Null:
                    _Sprite.color = Color.black;
                    break;
            }
        }

    }
}