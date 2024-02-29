using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class MapItem : MonoBehaviour
    {
        public Vector2Int _Pos;
        public MapManager MapRoot => GameRoot._Instance.GetManager<MapManager>();

        private static readonly int MainColor = Shader.PropertyToID("_MainColor");

        public void SetColor(Color color)
        {
            Material mat = GetComponent<MeshRenderer>().material;
            mat.SetColor(MainColor, color);
        }

        private void OnMouseEnter()
        {
            GameEvent.Send(MapItemEvent.MouseEnterEventID, this);
        }

        private void OnMouseOver()
        {
            GameEvent.Send(MapItemEvent.MouseOverEventID, this);
        }

        private void OnMouseDown()
        {
            GameEvent.Send(MapItemEvent.MouseDownEventID, this);
        }

        private void OnMouseExit()
        {
            GameEvent.Send(MapItemEvent.MouseExitEventID, this);
        }
    }
}