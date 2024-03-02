using System;
using TMPro;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanMapItem
    {
        private Enum_MaptemType _type;
        public GameObject _Obj;
        public Vector2Int _Pos;

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
        public TextMeshPro _TextMesh;


        public void UpdateState()
        {
            if (_Sprite == null) return;
            // _TextMesh.text = $"{(int)_type}";
            _Sprite.sprite = SokobanGameRoot._Instance._Map.GetSprite(_type);
            _Sprite.size = Vector2.one;
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
                    _Sprite.color = Color.white;
                    break;
                case (Enum_MaptemType)20: // 玩家 | 目标位置
                    _Sprite.color = Color.white;
                    break;
            }
        }
    }
}