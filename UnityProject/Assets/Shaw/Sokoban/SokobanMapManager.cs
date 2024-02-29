using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameLogic;
using Shaw.Sokoban;
using UnityEditor;
using UnityEngine;

public class SokobanMapManager : Manager
{
    public Dictionary<Vector2Int, SokobanMapItem> _Dict_Map = new Dictionary<Vector2Int, SokobanMapItem>();

    public Vector2Int _PlayerPos;

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
                    _Dict_Map[new Vector2Int(x, y)] = new SokobanMapItem { _Type = (Enum_Sokoban)value };
                }

                x++;
            }

            y++;
        }


        CreateMap(_Dict_Map);


        PlayerController.PlayerUpEvent += MoveUp;
        PlayerController.PlayerDownEvent += MoveDown;
        PlayerController.PlayerLeftEvent += MoveLeft;
        PlayerController.PlayerRightEvent += MoveRight;
    }

    private void CreateMap(Dictionary<Vector2Int, SokobanMapItem> dictMap)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Square.prefab");
        foreach (var (key, value) in dictMap)
        {
            if ((value._Type & Enum_Sokoban.Player) != 0)
            {
                _PlayerPos = key;
            }

            GameObject obj = Instantiate(prefab, transform);
            obj.transform.position = new Vector3(key.x, key.y);
            obj.name = key.ToString();
            value._Obj = obj;
            value._Pos = key;
            value._Sprite = obj.GetComponent<SpriteRenderer>();

            value.UpdateState();
        }
    }

    private void MoveUp()
    {
        Vector2Int originPos = _PlayerPos;
        Vector2Int newPos = _PlayerPos + Vector2Int.up;
        if (IsEqual(_Dict_Map[newPos]._Type, Enum_Sokoban.Ground))
        {
            _Dict_Map[newPos]._Type |= Enum_Sokoban.Player;
            _Dict_Map[originPos]._Type &= ~Enum_Sokoban.Player;
            _PlayerPos = newPos;


            _Dict_Map[originPos].UpdateState();
            _Dict_Map[newPos].UpdateState();
        }
    }
    private void MoveRight()
    {
        Vector2Int originPos = _PlayerPos;
        Vector2Int newPos = _PlayerPos + Vector2Int.right;
        if (IsEqual(_Dict_Map[newPos]._Type, Enum_Sokoban.Ground))
        {
            _Dict_Map[newPos]._Type |= Enum_Sokoban.Player;
            _Dict_Map[originPos]._Type &= ~Enum_Sokoban.Player;
            _PlayerPos = newPos;


            _Dict_Map[originPos].UpdateState();
            _Dict_Map[newPos].UpdateState();
        }
    }
    private void MoveDown()
    {
        Vector2Int originPos = _PlayerPos;
        Vector2Int newPos = _PlayerPos + Vector2Int.down;
        if (IsEqual(_Dict_Map[newPos]._Type, Enum_Sokoban.Ground))
        {
            _Dict_Map[newPos]._Type |= Enum_Sokoban.Player;
            _Dict_Map[originPos]._Type &= ~Enum_Sokoban.Player;
            _PlayerPos = newPos;


            _Dict_Map[originPos].UpdateState();
            _Dict_Map[newPos].UpdateState();
        }
    }
    private void MoveLeft()
    {
        Vector2Int originPos = _PlayerPos;
        Vector2Int newPos = _PlayerPos + Vector2Int.left;
        if (IsEqual(_Dict_Map[newPos]._Type, Enum_Sokoban.Ground))
        {
            _Dict_Map[newPos]._Type |= Enum_Sokoban.Player;
            _Dict_Map[originPos]._Type &= ~Enum_Sokoban.Player;
            _PlayerPos = newPos;


            _Dict_Map[originPos].UpdateState();
            _Dict_Map[newPos].UpdateState();
        }
    }

    public bool IsEqual(Enum_Sokoban t1, Enum_Sokoban t2)
    {
        return (t1 & t2) != 0;
    }
}

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