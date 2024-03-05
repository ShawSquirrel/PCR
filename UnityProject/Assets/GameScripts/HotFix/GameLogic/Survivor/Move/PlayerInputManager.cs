using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class PlayerInputManager : Manager
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
            _BeginDragPos = pos;
            GameEvent.Send<Vector2>(SurvivorEvent.Survivor_UIBeginDragStick, pos);
        }

        private void OnDrag(Vector2 pos)
        {
            Vector2 handlePos;
            Vector2 direct = (pos - _BeginDragPos).normalized;
            if ((pos - _BeginDragPos).magnitude < 90)
            {
                handlePos = pos;
            }
            else
            {
                handlePos =_BeginDragPos +  direct * 90;
            }
            GameEvent.Send<Vector2>(SurvivorEvent.Survivor_UIDragStick, handlePos);

            
            GameEvent.Send<Vector2>(SurvivorEvent.Survivor_Move, direct);
        }

        private void OnEndDrag(Vector2 pos)
        {
            // Log.Info($"OnEndDrag {pos}");
            GameEvent.Send(SurvivorEvent.Survivor_UIEndDragStick);
            GameEvent.Send<Vector2>(SurvivorEvent.Survivor_MoveStop, new Vector2());
        }
    }
}