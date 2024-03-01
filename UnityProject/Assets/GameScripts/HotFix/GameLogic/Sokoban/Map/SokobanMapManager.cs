using System.Collections.Generic;
using System.IO;
using TEngine;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanMapManager : GameBase.Manager
    {
        public Dictionary<Vector2Int, SokobanMapItem> _Dict_Map = new Dictionary<Vector2Int, SokobanMapItem>();
        public Dictionary<Enum_MaptemType, Sprite> _Dict_Sprite = new Dictionary<Enum_MaptemType, Sprite>();

        public Vector2Int _PlayerPos;
        public List<Vector2Int> _List_TargetPos = new List<Vector2Int>();

        public override void Awake()
        {
            LoadSprite();

            LoadMap();

            CreateMap(_Dict_Map);

            AddListen();
            
        }

        public void Init()
        {
            UpdatePlayerPos(_PlayerPos);
        }

        private void AddListen()
        {
            PlayerInputManager.PlayerUpEvent += MoveUp;
            PlayerInputManager.PlayerDownEvent += MoveDown;
            PlayerInputManager.PlayerLeftEvent += MoveLeft;
            PlayerInputManager.PlayerRightEvent += MoveRight;
        }

        private void LoadMap()
        {
            TextAsset textAsset = GameModule.Resource.LoadAsset<TextAsset>("Map");
            string[] mapRow = textAsset.text.Trim('\n').Split('\n');
            int y = 0;
            foreach (string row in mapRow)
            {
                int x = 0;
                string[] split = row.Trim(' ').Split('|');
                foreach (string s in split)
                {
                    if (int.TryParse(s, out int value))
                    {
                        _Dict_Map[new Vector2Int(x, y)] = new SokobanMapItem { Type = (Enum_MaptemType)value };
                    }

                    x++;
                }

                y++;
            }
        }

        private void LoadSprite()
        {
            _Dict_Sprite[(Enum_MaptemType)1] = GameModule.Resource.LoadAsset<Sprite>("White");
            _Dict_Sprite[(Enum_MaptemType)2] = GameModule.Resource.LoadAsset<Sprite>("White");
            _Dict_Sprite[(Enum_MaptemType)4] = GameModule.Resource.LoadAsset<Sprite>("Blue");
            _Dict_Sprite[(Enum_MaptemType)10] = GameModule.Resource.LoadAsset<Sprite>("Green");
            _Dict_Sprite[(Enum_MaptemType)12] = GameModule.Resource.LoadAsset<Sprite>("Gold");
            _Dict_Sprite[(Enum_MaptemType)20] = GameModule.Resource.LoadAsset<Sprite>("Blue");
        }

        public Sprite GetSprite(Enum_MaptemType type)
        {
            return _Dict_Sprite.GetValueOrDefault(type);
        }

        private void CreateMap(Dictionary<Vector2Int, SokobanMapItem> dictMap)
        {
            _List_TargetPos.Clear();
            GameObject prefab = GameModule.Resource.LoadAsset<GameObject>("SokobanMapItem");
            foreach (var (key, value) in dictMap)
            {
                if (IsContain(value.Type, Enum_MaptemType.Player))
                {
                    _PlayerPos = key;
                }

                if (IsContain(value.Type, Enum_MaptemType.Target))
                {
                    _List_TargetPos.Add(key);
                }

                GameObject obj = GameObject.Instantiate(prefab, _Obj.transform);
                obj.transform.position = new Vector3(key.x, key.y);
                obj.name = key.ToString();
                value._Obj = obj;
                value._Pos = key;
                value._Sprite = obj.GetComponent<SpriteRenderer>();
                value._TextMesh = obj.GetComponentInChildren<TextMeshPro>();

                value.UpdateState();
            }

            GameObject.Destroy(prefab);
        }

        private void MoveUp()
        {
            Move(Vector2Int.up);
        }

        private void MoveRight()
        {
            Move(Vector2Int.right);
        }

        private void MoveDown()
        {
            Move(Vector2Int.down);
        }

        private void MoveLeft()
        {
            Move(Vector2Int.left);
        }

        private bool IsContain(Enum_MaptemType t1, Enum_MaptemType t2)
        {
            return (t1 & t2) != 0;
        }

        private bool IsEqual(Enum_MaptemType t1, Enum_MaptemType t2)
        {
            return t1 == t2;
        }

        private void Move(Vector2Int dir)
        {
            Vector2Int originPos = _PlayerPos;
            Vector2Int newPos = _PlayerPos + dir;
            Vector2Int originPos_Add2 = _PlayerPos + dir * 2;

            if (!_Dict_Map.TryGetValue(newPos, out SokobanMapItem newPosItem))
            {
                return;
            }

            _Dict_Map.TryGetValue(originPos_Add2, out SokobanMapItem originPos_Add2Item);

            switch (newPosItem.Type)
            {
                case (Enum_MaptemType)0: // 空
                case (Enum_MaptemType)1: // 墙
                    return;
                case (Enum_MaptemType)2: // 空地
                case (Enum_MaptemType)4: // 目标位置
                    _Dict_Map[newPos].Type |= Enum_MaptemType.Player;
                    _Dict_Map[originPos].Type &= ~Enum_MaptemType.Player;
                    _PlayerPos = newPos;
                    break;
                case (Enum_MaptemType)10: // 箱子 | 空地
                case (Enum_MaptemType)12: // 箱子 | 目标位置
                    if (originPos_Add2Item == null) return;
                    switch (originPos_Add2Item.Type)
                    {
                        case (Enum_MaptemType)0: // 空
                        case (Enum_MaptemType)1: // 墙
                            return;
                        case (Enum_MaptemType)2: // 空地
                        case (Enum_MaptemType)4: // 目标位置
                            _Dict_Map[originPos].Type &= ~Enum_MaptemType.Player;
                            _Dict_Map[newPos].Type &= ~Enum_MaptemType.Box;
                            _Dict_Map[newPos].Type |= Enum_MaptemType.Player;
                            _Dict_Map[originPos_Add2].Type |= Enum_MaptemType.Box;
                            _PlayerPos = newPos;
                            break;
                        case (Enum_MaptemType)10: // 箱子 | 空地
                        case (Enum_MaptemType)12: // 箱子 | 目标位置
                        case (Enum_MaptemType)18: // 玩家 | 空地
                        case (Enum_MaptemType)20: // 玩家 | 目标位置
                            return;
                    }

                    break;
            }


            bool isCompelte = true;
            foreach (Vector2Int pos in _List_TargetPos)
            {
                isCompelte = isCompelte && IsEqual(_Dict_Map[pos].Type, (Enum_MaptemType)12);
            }


            UpdatePlayerPos(newPos);

            if (isCompelte)
            {
                GameModule.UI.ShowUI<UI_SokobanSuccess>();
            }
        }

        private static void UpdatePlayerPos(Vector2Int newPos)
        {
            SokobanGameRoot._Instance._Player.SetPos(newPos);
        }
    }
}