using System;
using TMPro;
using UnityEngine;

namespace Shaw.Sokoban
{
    public class SokobanMapItem
    {
        private Enum_Sokoban _type;
        public GameObject _Obj;
        public Vector2Int _Pos;

        public Enum_Sokoban Type
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
            _TextMesh.text = $"{(int)_type}";
            switch (_type)
            {
                case Enum_Sokoban.Empty:
                    _Sprite.color = Color.clear;
                    break;
                case Enum_Sokoban.Wall:
                    _Sprite.color = Color.gray;
                    break;
                case Enum_Sokoban.Ground:
                    _Sprite.color = Color.black;
                    break;
                case Enum_Sokoban.Target:
                    _Sprite.color = Color.red;
                    break;
                case Enum_Sokoban.Box:
                    _Sprite.color = Color.yellow;
                    break;
                case Enum_Sokoban.Player:
                    _Sprite.color = Color.cyan;
                    break;
                case (Enum_Sokoban)18:
                    _Sprite.color = Color.cyan;
                    break;
            }
        }
    }
}