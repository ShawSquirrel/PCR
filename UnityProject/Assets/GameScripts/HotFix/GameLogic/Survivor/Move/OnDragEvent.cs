using System.Collections;
using System.Collections.Generic;
using TEngine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameLogic.Survivor
{
    public class OnDragEvent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            
            GameEvent.Send(EventID_Survivor.Survivor_BeginDragStick, eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            GameEvent.Send(EventID_Survivor.Survivor_DragStick, eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GameEvent.Send(EventID_Survivor.Survivor_EndDragStick, eventData.position);
        }
    }
}
