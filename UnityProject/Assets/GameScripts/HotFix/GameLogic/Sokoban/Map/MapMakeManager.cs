using System.Collections.Generic;
using Lean.Touch;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class MapMakeManager : GameBase.Manager
    {
        public Dictionary<Vector2Int, MakeMapItem> _Dict_MakeItem = new Dictionary<Vector2Int, MakeMapItem>();

        public Enum_MaptemType _SelectType = Enum_MaptemType.Null;

        public LeanSelectByFinger _LeanSelectByFinger;
        public LeanFingerDown _LeanFingerDown;
        
        public void LoadMakeMapScene()
        {
            _SelectType = Enum_MaptemType.Null;
            _Dict_MakeItem?.Clear();
            GameObject prefab = GameModule.Resource.LoadAsset<GameObject>("SokobanMakeMapItem");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject obj = GameObject.Instantiate(prefab, _TF);
                    obj.transform.localPosition = new Vector3(i, j);
                    Vector2Int pos = new Vector2Int(i, j);
                    MakeMapItem makeMapItem = obj.AddComponent<MakeMapItem>();
                    obj.name            = pos.ToString();
                    _Dict_MakeItem[pos] = makeMapItem;

                }
            }
            GameObject.Destroy(prefab);


            _LeanSelectByFinger = _Obj.AddComponent<LeanSelectByFinger>();
            _LeanFingerDown     = _Obj.AddComponent<LeanFingerDown>();
            _LeanFingerDown.OnFinger.AddListener(_LeanSelectByFinger.SelectScreenPosition);
        }

        public void OnReset()
        {
            foreach (var (key, value) in _Dict_MakeItem)
            {
                GameObject.Destroy(value.gameObject);
            }
            _Dict_MakeItem.Clear();
            _SelectType = Enum_MaptemType.Null;
        }

        public void Save(string levelName)
        {
            string map = $"##\n{levelName}\n";

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int type = (int)_Dict_MakeItem[new Vector2Int(j, i)].Type;
                    if (j == 9)
                    {
                        map += $"{type}\n";
                    }
                    else
                    {
                        map += $"{type}|";
                    }
                }
            }

            if (string.IsNullOrEmpty(PlayerPrefs.GetString(levelName, "")))
            {
                string levelRow = PlayerPrefs.GetString("LevelNameList", "");
                levelRow += $"\n{levelName}";
                PlayerPrefs.SetString("LevelNameList", levelRow);
            }

            PlayerPrefs.SetString(levelName, map);
            PlayerPrefs.Save();
        }

        public void Revert()
        {
            foreach (var (key, value) in _Dict_MakeItem)
            {
                value.Type = Enum_MaptemType.Null;
                value.UpdateState();
            }
        }
    }
}