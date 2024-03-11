using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class InputSystem : GameBase.System, IRelease
    {
        public Vector2 _BeginDragPos;

        public override void Awake()
        {
            base.Awake();
            AddListen();
        }

        private void AddListen()
        {
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_BeginDragStick, OnBeginDrag);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_DragStick, OnDrag);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_EndDragStick, OnEndDrag);
        }

        private void OnBeginDrag(Vector2 pos)
        {
            _BeginDragPos = pos;
            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_UIBeginDragStick, pos);
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
            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_UIDragStick, handlePos);

            
            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_Move, direct);
        }

        private void OnEndDrag(Vector2 pos)
        {
            GameEvent.Send(EventID_Survivor.Survivor_UIEndDragStick);
            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_MoveStop, new Vector2());
        }


        public void Release()
        {
            
        }
    }
}