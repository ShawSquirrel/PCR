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
            _TextMesh.text = $"{(int)_type}";
            switch (_type)
            {
                case Enum_MaptemType.Empty:
                    _Sprite.color = Color.clear;
                    break;
                case Enum_MaptemType.Wall:
                    _Sprite.color = Color.gray;
                    break;
                case Enum_MaptemType.Ground:
                    _Sprite.color = Color.black;
                    break;
                case Enum_MaptemType.Target:
                    _Sprite.color = Color.red;
                    break;
                case Enum_MaptemType.Box:
                    _Sprite.color = Color.yellow;
                    break;
                case Enum_MaptemType.Player:
                    _Sprite.color = Color.cyan;
                    break;
                case (Enum_MaptemType)18:
                    _Sprite.color = Color.cyan;
                    break;
            }
        }
    }
}