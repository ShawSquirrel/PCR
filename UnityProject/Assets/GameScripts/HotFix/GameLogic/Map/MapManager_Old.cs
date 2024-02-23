using System;
using System.Collections.Generic;
using TEngine;
using TMPro;
using UnityEngine;


namespace GameLogic
{
    public class MapItemData_Old
    {
        public MapItem_Old MapItemOld;
        public Character_Old CharacterOld;
    }

    public class MapManager_Old : Entity
    {
        public Transform _MapRoot;
        public Dictionary<Vector2Int, MapItemData_Old> _MapItemDataDict = new Dictionary<Vector2Int, MapItemData_Old>();

        protected override void Awake()
        {
            base.Awake();
            LevelManager.Instance._MapManager = this;
            _TF.SetParent(LevelManager.Instance._Root);

            _MapRoot = new GameObject("MapRoot").transform;
            _MapRoot.SetParent(_TF);
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
                    MapItem_Old mapItemOld = mapItemObj.AddComponent<MapItem_Old>();
                    mapItemOld.Init(sprite, new Vector2Int(i, ii));
                    _MapItemDataDict[new Vector2Int(i, ii)] = new MapItemData_Old { MapItemOld = mapItemOld };
                }
            }
        }


        /// <summary>
        /// 设置角色位置
        /// </summary>
        /// <param name="characterOld"></param>
        /// <param name="targetPos"></param>
        /// <param name="init"></param>
        public void SetCharacterPos(Character_Old characterOld, Vector2Int targetPos, bool init = false)
        {
            if (_MapItemDataDict[characterOld._CurPos].CharacterOld != null)
            {
                Log.Error("有问题");
                return;
            }

            if (!init) _MapItemDataDict[characterOld._CurPos] = null;
            characterOld._CurPos = targetPos;
            _MapItemDataDict[characterOld._CurPos].CharacterOld = characterOld;
        }
    }
}