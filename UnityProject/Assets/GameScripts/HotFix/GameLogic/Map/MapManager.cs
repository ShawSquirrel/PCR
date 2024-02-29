using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class MapManager : Manager
    {
        private Transform _leftRoot;
        private Transform _rightRoot;

        public Dictionary<Vector2Int, MapItem> Dict_VecToMapItem = new Dictionary<Vector2Int, MapItem>();

        private void Awake()
        {
            InitName();
            LoadMap();
            AddListen();
        }

        public MapItem GetMapItemByPos(Vector2Int pos)
        {
            return Dict_VecToMapItem.GetValueOrDefault(pos);
        }

        private void AddListen()
        {
            GameEvent.AddEventListener<MapItem>(MapItemEvent.MouseEnterEventID, OnMapItemMouseEnterEvent);
            GameEvent.AddEventListener<MapItem>(MapItemEvent.MouseExitEventID, OnMapItemMouseExitEvent);
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
                item._Pos = v2;
                item.name = v2.ToString();
            }

            for (int i = 0; i < _rightRoot.childCount; i++)
            {
                MapItem item = _rightRoot.GetChild(i).gameObject.AddComponent<MapItem>();

                v2.Set(i / 3 + 1, i % 3 + 1);
                Dict_VecToMapItem[v2] = item;
                item.name = v2.ToString();
            }
        }
    }
}