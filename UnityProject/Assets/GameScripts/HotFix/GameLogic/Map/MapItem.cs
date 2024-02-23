using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class MapItem : MonoBehaviour
    {
        public MapManager MapRoot => GameRoot._Instance.GetManager<MapManager>();

        private static readonly int MainColor = Shader.PropertyToID("_MainColor");

        public void SetColor(Color color)
        {
            Material mat = GetComponent<MeshRenderer>().material;
            mat.SetColor(MainColor, color);
        }

        private void OnMouseEnter()
        {
            GameEvent.Send(MapItemEvent.MouseEnterEvent, this);
        }

        private void OnMouseOver()
        {
            GameEvent.Send(MapItemEvent.MouseOverEvent, this);
        }

        private void OnMouseDown()
        {
            GameEvent.Send(MapItemEvent.MouseDownEvent, this);
        }

        private void OnMouseExit()
        {
            GameEvent.Send(MapItemEvent.MouseExitEvent, this);
        }
    }
}