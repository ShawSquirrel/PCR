using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanLevelItem
    {
        public int _Int_ID;
        public string _Str_Name;
        public Dictionary<Vector2Int, Enum_MaptemType> _Dict_Map = new Dictionary<Vector2Int, Enum_MaptemType>();
    }

    public class SokobanLevelManager : GameBase.Manager
    {
        public List<SokobanLevelItem> _List_Level = new List<SokobanLevelItem>();
        public SokobanLevelItem _CurLevel;

        public override void Awake()
        {
            base.Awake();
            LoadAllMap();

            // string[] mapRow = textAsset.text.Trim('\n').Split('\n');
            // int y = 0;
            // foreach (string row in mapRow)
            // {
            //     int x = 0;
            //     string[] split = row.Trim(' ').Split('|');
            //     foreach (string s in split)
            //     {
            //         if (int.TryParse(s, out int value))
            //         {
            //             _Dict_Map[new Vector2Int(x, y)] = new SokobanMapItem { Type = (Enum_MaptemType)value };
            //         }
            //
            //         x++;
            //     }
            //
            //     y++;
            // }
        }

        public bool SetCurLoadLevel(string levelName)
        {
            _CurLevel = _List_Level.Find(a => a._Str_Name == levelName);
            return _CurLevel != null;
        }

        private void LoadAllMap()
        {
            _List_Level.Clear();
            TextAsset textAsset = GameModule.Resource.LoadAsset<TextAsset>("Map");
            string[] levelArr = textAsset.text.Replace("\r", "").Trim(' ').Trim('\n').Split("##");

            for (int i = 0; i < levelArr.Length; i++)
            {
                string level = levelArr[i];
                string[] levelRow = level.Trim('\n').Split("\n");

                if (levelRow.Length < 2) continue;

                SokobanLevelItem sokobanLevel = new SokobanLevelItem();
                sokobanLevel._Int_ID   = i;
                sokobanLevel._Str_Name = levelRow[0];

                int y = 0;
                for (int i1 = 1; i1 < levelRow.Length; i1++)
                {
                    int x = 0;
                    string[] split = levelRow[i1].Trim(' ').Split('|');
                    foreach (string s in split)
                    {
                        if (int.TryParse(s, out int value))
                        {
                            sokobanLevel._Dict_Map[new Vector2Int(x, y)] = (Enum_MaptemType)value;
                        }

                        x++;
                    }

                    y++;
                }

                _List_Level.Add(sokobanLevel);
            }
        }
    }
}