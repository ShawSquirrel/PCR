using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class MapItemData
    {
        public Vector2Int _Index;
        public Character _Character;
    }

    public class MapManager : MonoBehaviour
    {
        private Transform _leftRoot;
        private Transform _rightRoot;

        public Dictionary<Vector2Int, MapItem> Dict_VecToMapItem = new Dictionary<Vector2Int, MapItem>();
        public Dictionary<MapItem, MapItemData> Dict_MapItemToData = new Dictionary<MapItem, MapItemData>();

        private void Awake()
        {
            InitName();
            LoadMap();

            AddListen();
        }

        private void AddListen()
        {
            GameEvent.AddEventListener<MapItem>(MapItemEvent.MouseEnterEvent, OnMapItemMouseEnterEvent);
            GameEvent.AddEventListener<MapItem>(MapItemEvent.MouseExitEvent, OnMapItemMouseExitEvent);
        }

        private void OnMapItemMouseExitEvent(MapItem item)
        {
            item.SetColor(Color.white);
        }

        private void OnMapItemMouseEnterEvent(MapItem item)
        {
            item.SetColor(Color.cyan);
        }

        protected void InitName()
        {
            name = "MapManager";
        }

        protected void LoadMap()
        {
            _leftRoot = GameModule.Resource.LoadAsset<GameObject>("Left").transform;
            _rightRoot = GameModule.Resource.LoadAsset<GameObject>("Right").transform;

            _leftRoot.SetParent(transform);
            _rightRoot.SetParent(transform);

            Vector2Int v2 = Vector2Int.zero;
            for (int i = 0; i < _leftRoot.childCount; i++)
            {
                MapItem item = _leftRoot.GetChild(i).gameObject.AddComponent<MapItem>();

                v2.Set(-i / 3 - 1, -i % 3 - 1);
                Dict_VecToMapItem[v2] = item;
                Dict_MapItemToData[item] = new MapItemData
                {
                    _Index = v2,
                    _Character = null
                };

                item.name = v2.ToString();
            }

            for (int i = 0; i < _rightRoot.childCount; i++)
            {
                MapItem item = _rightRoot.GetChild(i).gameObject.AddComponent<MapItem>();

                v2.Set(i / 3 + 1, i % 3 + 1);
                Dict_VecToMapItem[v2] = item;

                Dict_MapItemToData[item] = new MapItemData
                {
                    _Index = v2,
                    _Character = null
                };

                item.name = v2.ToString();
            }
        }
    }
}