using System;
using GameBase;
using TEngine;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace GameLogic
{
    public class MapItem_Old : MonoBehaviour
    {
        public GameObject _GO;
        public Transform _TF;
        public SpriteRenderer _SpriteRenderer;
        public TextMeshPro _TextMesh;
        public Vector2Int _Pos;

        private void Awake()
        {
            _GO             = gameObject;
            _TF             = transform;
            _SpriteRenderer = _GO.AddComponent<SpriteRenderer>();
            _TextMesh       = new GameObject("Text").AddComponent<TextMeshPro>();
            _TextMesh.transform.SetParent(_TF);
            _TextMesh.transform.Reset();
            _TextMesh.fontSize                                             = 3;
            _TextMesh.alignment                                            = TextAlignmentOptions.Center;
            _TextMesh.color                                                = Color.cyan;
            _TextMesh.gameObject.AddComponent<SortingGroup>().sortingOrder = 1;
        }

        public void Init(Sprite sprite, Vector2Int pos)
        {
            _SpriteRenderer.sprite = sprite;
            _Pos                    = pos;

            _GO.AddComponent<BoxCollider2D>();
            _TF.localPosition = new Vector3(pos.x, pos.y);
            _TF.localRotation = Quaternion.Euler(Vector3.zero);
            _TF.localScale    = Vector3.one;

            _TextMesh.text = pos.ToString();
        }

        public void OnMouseDown()
        {
            LevelManager.Instance.ClickMapItem(_Pos);
        }
    }
}