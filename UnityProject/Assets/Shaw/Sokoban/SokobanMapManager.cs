using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameLogic;
using Shaw.Sokoban;
using TEngine;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SokobanMapManager : Manager
{
    public Dictionary<Vector2Int, SokobanMapItem> _Dict_Map = new Dictionary<Vector2Int, SokobanMapItem>();

    public Vector2Int _PlayerPos;
    public List<Vector2Int> _List_TargetPos = new List<Vector2Int>();

    private void Awake()
    {
        string[] mapRow = File.ReadAllLines("Assets/Shaw/Sokoban/Map.txt");
        int y = 0;
        foreach (string row in mapRow)
        {
            int x = 0;
            string[] split = row.Trim(' ').Split('|');
            foreach (string s in split)
            {
                if (int.TryParse(s, out int value))
                {
                    _Dict_Map[new Vector2Int(x, y)] = new SokobanMapItem { Type = (Enum_Sokoban)value };
                }

                x++;
            }

            y++;
        }


        CreateMap(_Dict_Map);


        PlayerController.PlayerUpEvent    += MoveUp;
        PlayerController.PlayerDownEvent  += MoveDown;
        PlayerController.PlayerLeftEvent  += MoveLeft;
        PlayerController.PlayerRightEvent += MoveRight;
    }

    private void CreateMap(Dictionary<Vector2Int, SokobanMapItem> dictMap)
    {
        _List_TargetPos.Clear();
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Square.prefab");
        foreach (var (key, value) in dictMap)
        {
            if (IsContain(value.Type, Enum_Sokoban.Player))
            {
                _PlayerPos = key;
            }

            if (IsContain(value.Type, Enum_Sokoban.Target))
            {
                _List_TargetPos.Add(key);
            }

            GameObject obj = Instantiate(prefab, transform);
            obj.transform.position = new Vector3(key.x, key.y);
            obj.name               = key.ToString();
            value._Obj             = obj;
            value._Pos             = key;
            value._Sprite          = obj.GetComponent<SpriteRenderer>();
            value._TextMesh        = obj.GetComponentInChildren<TextMeshPro>();

            value.UpdateState();
        }
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

    private bool IsContain(Enum_Sokoban t1, Enum_Sokoban t2)
    {
        return (t1 & t2) != 0;
    }

    private bool IsEqual(Enum_Sokoban t1, Enum_Sokoban t2)
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
            case (Enum_Sokoban)0: // 空
            case (Enum_Sokoban)1: // 墙
                return;
            case (Enum_Sokoban)2: // 空地
            case (Enum_Sokoban)4: // 目标位置
                _Dict_Map[newPos].Type    |= Enum_Sokoban.Player;
                _Dict_Map[originPos].Type &= ~Enum_Sokoban.Player;
                _PlayerPos                =  newPos;
                break;
            case (Enum_Sokoban)10: // 箱子 | 空地
            case (Enum_Sokoban)12: // 箱子 | 目标位置
                if (originPos_Add2Item == null) return;
                switch (originPos_Add2Item.Type)
                {
                    case (Enum_Sokoban)0: // 空
                    case (Enum_Sokoban)1: // 墙
                        return;
                    case (Enum_Sokoban)2: // 空地
                    case (Enum_Sokoban)4: // 目标位置
                        _Dict_Map[originPos].Type      &= ~Enum_Sokoban.Player;
                        _Dict_Map[newPos].Type         &= ~Enum_Sokoban.Box;
                        _Dict_Map[newPos].Type         |= Enum_Sokoban.Player;
                        _Dict_Map[originPos_Add2].Type |= Enum_Sokoban.Box;
                        _PlayerPos                     =  newPos;
                        break;
                    case (Enum_Sokoban)10: // 箱子 | 空地
                    case (Enum_Sokoban)12: // 箱子 | 目标位置
                    case (Enum_Sokoban)18: // 玩家 | 空地
                    case (Enum_Sokoban)20: // 玩家 | 目标位置
                        return;
                }

                break;
        }


        bool isCompelte = true;
        foreach (Vector2Int pos in _List_TargetPos)
        {
            isCompelte = isCompelte && IsEqual(_Dict_Map[pos].Type, (Enum_Sokoban)12);
        }

        if (isCompelte)
        {
            Log.Info("游戏结束");
        }
    }
}

/*
switch (_Dict_Map[newPos]._Type)
{
    case (Enum_Sokoban)0: // 空
        break;
    case (Enum_Sokoban)1: // 墙
        break;
    case (Enum_Sokoban)2: // 空地
        break;
    case (Enum_Sokoban)4: // 目标位置
        break;
    case (Enum_Sokoban)10: // 箱子 | 空地
        break;
    case (Enum_Sokoban)12: // 箱子 | 目标位置
        break;
    case (Enum_Sokoban)18: // 玩家 | 空地
        break;
    case (Enum_Sokoban)20: // 玩家 | 目标位置
        break;
}
*/
[Flags]
public enum Enum_Sokoban
{
    Empty = 0,       // 空
    Wall = 1 << 0,   // 墙
    Ground = 1 << 1, // 空地
    Target = 1 << 2, // 目标位置
    Box = 1 << 3,    // 箱子
    Player = 1 << 4, // 玩家
}