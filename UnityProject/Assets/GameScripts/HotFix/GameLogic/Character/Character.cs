using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class Character : MonoBehaviour
    {
        public Vector2Int _Pos { get; private set; }


        public void SetPos(Vector2Int pos)
        {
            MapManager mapManager = GameRoot._Instance.GetManager<MapManager>();
            MapItem item = mapManager.GetMapItemByPos(pos);
            
            _Pos = pos;
            transform.position = item.transform.position += Vector3.back;
        }
    }
}