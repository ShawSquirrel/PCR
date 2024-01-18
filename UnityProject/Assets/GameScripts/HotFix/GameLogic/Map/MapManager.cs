using System;
using System.Collections.Generic;
using TEngine;
using TMPro;
using UnityEngine;

namespace GameLogic
{
    public class MapItemData
    {
        public MapItem _MapItem;
        public Character _Character;
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
                    _MapItemDataDict[new Vector2Int(i, ii)] = new MapItemData { _MapItem = mapItem };
                }
            }
        }

        
        /// <summary>
        /// 设置角色位置
        /// </summary>
        /// <param name="character"></param>
        /// <param name="targetPos"></param>
        /// <param name="init"></param>
        public void SetCharacterPos(Character character, Vector2Int targetPos, bool init = false)
        {
            if (_MapItemDataDict[character._CurPos]._Character != null)
            {
                Log.Error("有问题");
                return;
            }
            if (!init) _MapItemDataDict[character._CurPos] = null;
            character._CurPos                              = targetPos;
            _MapItemDataDict[character._CurPos]._Character = character;
        }
    }
}