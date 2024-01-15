using System;
using System.Collections.Generic;
using TEngine;
using TMPro;
using UnityEngine;

namespace GameLogic
{
    public class MapItemData
    {
        public MapItem MapItem;
    }

    public class MapManager : MonoBehaviour
    {
        public Transform _MapRoot;
        public Dictionary<Vector2Int, MapItemData> _MapItemDataDict = new Dictionary<Vector2Int, MapItemData>();

        private void Awake()
        {
            LevelManager.Instance._MapManager = this;
            
            _MapRoot = new GameObject("MapRoot").transform;
        }

        public void Init(MapData mapData)
        {
            _MapItemDataDict.Clear();


            Sprite sprite = GameModule.Resource.LoadAsset<Sprite>("MapItem@98x98");
            for (int i = 0; i < mapData._Width; i++)
            {
                for (int ii = 0; ii < mapData._Length; ii++)
                {
                    GameObject mapItemObj = new GameObject($"({i},{ii})");
                    mapItemObj.transform.SetParent(_MapRoot);
                    MapItem mapItem = mapItemObj.AddComponent<MapItem>();
                    mapItem.Init(sprite, new Vector2Int(i, ii));
                    _MapItemDataDict[new Vector2Int(i, ii)] = new MapItemData { MapItem = mapItem };
                }
            }
        }
    }
}