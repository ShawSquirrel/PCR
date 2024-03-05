using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class PlayerMoveManager : Manager
    {
        public Vector2 _BeginDragPos;

        public override void Awake()
        {
            base.Awake();
            AddListen();
        }

        private void AddListen()
        {
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_BeginDragStick, OnBeginDrag);
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_DragStick, OnDrag);
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_EndDragStick, OnEndDrag);
        }

        private void OnBeginDrag(Vector2 pos)
        {
            Log.Info($"OnBeginDrag {pos}");
            _BeginDragPos = pos;
            GameEvent.Send<Vector2>(SurvivorEvent.Survivor_UIBeginDragStick, pos);
        }

        private void OnDrag(Vector2 pos)
        {
            Log.Info($"OnDrag {pos}  MousePosition {Input.mousePosition}");
            Vector2 handlePos;
            if ((pos - _BeginDragPos).magnitude < 90)
            {
                handlePos = pos;
            }
            else
            {
                handlePos =_BeginDragPos +  (pos-_BeginDragPos).normalized * 90;
            }
            GameEvent.Send<Vector2>(SurvivorEvent.Survivor_UIDragStick, handlePos);
        }

        private void OnEndDrag(Vector2 pos)
        {
            Log.Info($"OnEndDrag {pos}");
            GameEvent.Send(SurvivorEvent.Survivor_UIEndDragStick);
        }
    }
}