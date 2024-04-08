using System;
using UnityEngine;
using TEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class InputSystem : Core.System
    {
        private static string Tag = "InputSystem\t";
        public override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            base.Init();
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    MLog.Debug($"{Tag}添加Update事件");
                    Utility.Unity.AddUpdateListener(Update);
                    break;
                case RuntimePlatform.Android:
                    // GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_BeginDragStick, OnBeginDrag);
                    // GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_DragStick, OnDrag);
                    // GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_EndDragStick, OnEndDrag);
                    break;
            }
        }

        public override void Release()
        {
            base.Release();
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    MLog.Debug($"{Tag}移除Update事件");
                    Utility.Unity.RemoveUpdateListener(Update);
                    break;
                case RuntimePlatform.Android:
                    // GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_BeginDragStick, OnBeginDrag);
                    // GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_DragStick, OnDrag);
                    // GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_EndDragStick, OnEndDrag);
                    break;
            }
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void Update()
        {
            MoveInput();
            // SkillInput();
        }

        private void SkillInput()
        {
            Vector2 mouse = Input.mousePosition;
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 vectorToConvert = mouse - center;
            float angleRadians = Mathf.Atan2(vectorToConvert.y, vectorToConvert.x);
            float angle = angleRadians * Mathf.Rad2Deg;

            // GameEvent.Send(EventID_Survivor.Survivor_SkillAngle, angle);
        }

        private void MoveInput()
        {
            CharacterModel characterModel = SurvivorRoot.Instance.GetModel<CharacterModel>();
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
                characterModel._CharacterSpeed.Value = Vector2.zero;
            else
                characterModel._CharacterSpeed.Value = vector2.normalized;
        }

        private void OnBeginDrag(Vector2 pos)
        {
            // _BeginDragPos = pos;
            // GameEvent.Send<Vector2>(EventID_Survivor.Survivor_UIBeginDragStick, pos);
        }

        private void OnDrag(Vector2 pos)
        {
            // Vector2 handlePos;
            // Vector2 direct = (pos - _BeginDragPos).normalized;
            // if ((pos - _BeginDragPos).magnitude < 90)
            // {
            //     handlePos = pos;
            // }
            // else
            // {
            //     handlePos = _BeginDragPos + direct * 90;
            // }

            // GameEvent.Send<Vector2>(EventID_Survivor.Survivor_UIDragStick, handlePos);
            // GameEvent.Send<Vector2>(EventID_Survivor.Survivor_Move, direct);
        }

        private void OnEndDrag(Vector2 pos)
        {
            // GameEvent.Send(EventID_Survivor.Survivor_UIEndDragStick);
            // GameEvent.Send<Vector2>(EventID_Survivor.Survivor_MoveStop, new Vector2());
        }
    }
}