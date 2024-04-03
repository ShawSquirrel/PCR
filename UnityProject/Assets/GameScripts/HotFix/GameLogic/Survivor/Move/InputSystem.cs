using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class InputSystem : GameBase.System, IRelease
    {
        /// <summary>
        /// 开始移动的距离
        /// </summary>
        public Vector2 _BeginDragPos;

        public override void Awake()
        {
            base.Awake();
        }

        #region Start Release

        public void Start()
        {
            AddListen();
        }

        public void Release()
        {
            RemoveListen();
        }

        #endregion

        private void AddListen()
        {
#if UNITY_EDITOR
            Utility.Unity.AddUpdateListener(Update);
#elif UNITY_STANDALONE
            Utility.Unity.AddUpdateListener(Update);
#elif UNITY_ANDROID
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_BeginDragStick, OnBeginDrag);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_DragStick, OnDrag);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_EndDragStick, OnEndDrag);
#endif
        }

        private void RemoveListen()
        {
#if UNITY_EDITOR
            Utility.Unity.RemoveUpdateListener(Update);
#elif UNITY_STANDALONE
            Utility.Unity.RemoveUpdateListener(Update);
#elif UNITY_ANDROID
            GameEvent.RemoveEventListener<Vector2>(EventID_Survivor.Survivor_BeginDragStick, OnBeginDrag);
            GameEvent.RemoveEventListener<Vector2>(EventID_Survivor.Survivor_DragStick, OnDrag);
            GameEvent.RemoveEventListener<Vector2>(EventID_Survivor.Survivor_EndDragStick, OnEndDrag);
#endif
        }

        private void Update()
        {
            MoveInput();
            SkillInput();
        }

        private void SkillInput()
        {
            Vector2 mouse = Input.mousePosition;
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 vectorToConvert = mouse - center;
            float angleRadians = Mathf.Atan2(vectorToConvert.y, vectorToConvert.x);
            float angle = angleRadians * Mathf.Rad2Deg;
            
            GameEvent.Send(EventID_Survivor.Survivor_SkillAngle, angle);
        }

        private void MoveInput()
        {
            Vector2 vector2 = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                vector2.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                vector2.x = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                vector2.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                vector2.y = -1;
            }
            if (vector2 == Vector2.zero)
            {
                GameEvent.Send<Vector2>(EventID_Survivor.Survivor_MoveStop, new Vector2());
            }
            else
            {
                GameEvent.Send<Vector2>(EventID_Survivor.Survivor_Move, vector2.normalized);
            }
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
                handlePos = _BeginDragPos + direct * 90;
            }

            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_UIDragStick, handlePos);
            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_Move, direct);
        }

        private void OnEndDrag(Vector2 pos)
        {
            GameEvent.Send(EventID_Survivor.Survivor_UIEndDragStick);
            GameEvent.Send<Vector2>(EventID_Survivor.Survivor_MoveStop, new Vector2());
        }
    }
}