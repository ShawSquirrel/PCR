using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController _Instance;

    public Transform Left;
    public Transform Right;
    public MapItem[,] LeftMap = new MapItem[3, 3];
    public MapItem[,] RightMap = new MapItem[3, 3];

    public Dictionary<MapItem, Vector2Int> MapItemToVec = new Dictionary<MapItem, Vector2Int>();


    private void Awake()
    {
        _Instance = this;
        LoadMap();
    }

    private void LoadMap()
    {
        MapItem item;
        Vector2Int v2 = Vector2Int.zero;

        for (int i = 0; i < Left.childCount; i++)
        {
            item = Left.GetChild(i).GetComponent<MapItem>();
            v2.Set(i / 3, i % 3);
            LeftMap[v2.x, v2.y] = item;
            MapItemToVec[item] = v2;

            item.name = v2.ToString();
        }

        for (int i = 0; i < Right.childCount; i++)
        {
            item = Right.GetChild(i).GetComponent<MapItem>();
            v2.Set(i / 3, i % 3);
            RightMap[v2.x, v2.y] = item;
            MapItemToVec[item] = v2;

            item.name = v2.ToString();
        }
    }

    public MapItem GetTargetUpMapItem(MapItem target)
    {
        Vector2Int index;
        if (!MapItemToVec.TryGetValue(target, out index)) return null;
        index += Vector2Int.up;
        if (!IsValueOk(index)) return null;
        return RightMap[index.x, index.y];
    }

    public MapItem GetTargetDownMapItem(MapItem target)
    {
        Vector2Int index;
        if (!MapItemToVec.TryGetValue(target, out index)) return null;
        index += Vector2Int.down;
        if (!IsValueOk(index)) return null;
        return RightMap[index.x, index.y];
    }

    public MapItem GetTargetLeftMapItem(MapItem target)
    {
        Vector2Int index;
        if (!MapItemToVec.TryGetValue(target, out index)) return null;
        index += Vector2Int.left;
        if (!IsValueOk(index)) return null;
        return RightMap[index.x, index.y];
    }

    public MapItem GetTargetRightMapItem(MapItem target)
    {
        Vector2Int index;
        if (!MapItemToVec.TryGetValue(target, out index)) return null;
        index += Vector2Int.right;
        if (!IsValueOk(index)) return null;
        return RightMap[index.x, index.y];
    }


    public bool IsValueOk(Vector2Int index)
    {
        if (index.x < 0 || index.x > 2)
            return false;
        if (index.y < 0 || index.y > 2)
            return false;
        return true;
    }
}