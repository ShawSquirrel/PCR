using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using UnityEngine.EventSystems;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_SurvivorStick : UIWindow
    {
        #region 脚本工具生成的代码
        private GameObject _Obj_Bg;
        private Image _Img_Stick;
        private Image _Img_Handle;
        public override void ScriptGenerator()
        {
            _Obj_Bg = FindChild("_Obj_Bg").gameObject;
            _Img_Stick = FindChildComponent<Image>("_Obj_Bg/_Img_Stick");
            _Img_Handle = FindChildComponent<Image>("_Obj_Bg/_Img_Handle");
        }
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _Obj_Bg.AddComponent<GameLogic.Survivor.OnDragEvent>();
            
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_UIBeginDragStick, OnBeginDrag);
            GameEvent.AddEventListener<Vector2>(SurvivorEvent.Survivor_UIDragStick, OnDrag);
            GameEvent.AddEventListener(SurvivorEvent.Survivor_UIEndDragStick, OnEndDrag);

        }

        public void SetStickActive(bool isActive)
        {
            _Img_Stick.gameObject.SetActive(isActive);
        }
        public void SetHandleActive(bool isActive)
        {
            _Img_Handle.gameObject.SetActive(isActive);
        }

        public void SetStickPos(Vector2 pos)
        {
            _Img_Stick.GetComponent<RectTransform>().anchoredPosition = pos;
        }

        public void SetHandlePos(Vector2 pos)
        {
            _Img_Handle.GetComponent<RectTransform>().anchoredPosition = pos;
        }

        public void OnBeginDrag(Vector2 pos)
        {
            SetStickActive(true);
            SetHandleActive(true);
            SetStickPos(pos);
            SetHandlePos(pos);
        }

        public void OnDrag(Vector2 pos)
        {
            SetHandlePos(pos);
        }

        public void OnEndDrag()
        {
            SetStickActive(false);
            SetHandleActive(false);
        }
    }
}