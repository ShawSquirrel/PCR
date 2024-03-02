using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class MapMakeManager : GameBase.Manager
    {
        public Dictionary<Vector2Int, MakeMapItem> _Dict_MakeItem = new Dictionary<Vector2Int, MakeMapItem>();

        public Enum_MaptemType _SelectType = Enum_MaptemType.Null;
        
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
        }

        public void OnReset()
        {
            
        }
    }
}