using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Launching : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _Btn_Restart;
        private Button _Btn_Menu;
        private Button _Btn_Up;
        private Button _Btn_Down;
        private Button _Btn_Left;
        private Button _Btn_Right;
        public override void ScriptGenerator()
        {
            _Btn_Restart = FindChildComponent<Button>("_Btn_Restart");
            _Btn_Menu = FindChildComponent<Button>("_Btn_Menu");
            _Btn_Up = FindChildComponent<Button>("BtnBg/_Btn_Up");
            _Btn_Down = FindChildComponent<Button>("BtnBg/_Btn_Down");
            _Btn_Left = FindChildComponent<Button>("BtnBg/_Btn_Left");
            _Btn_Right = FindChildComponent<Button>("BtnBg/_Btn_Right");
            _Btn_Restart.onClick.AddListener(OnClick_Btn_RestartBtn);
            _Btn_Menu.onClick.AddListener(OnClick_Btn_MenuBtn);
            _Btn_Up.onClick.AddListener(OnClick_Btn_UpBtn);
            _Btn_Down.onClick.AddListener(OnClick_Btn_DownBtn);
            _Btn_Left.onClick.AddListener(OnClick_Btn_LeftBtn);
            _Btn_Right.onClick.AddListener(OnClick_Btn_RightBtn);
        }
        #endregion
        #region 事件

        private void OnClick_Btn_RestartBtn()
        {
            // GameEvent.Send(UIEventID.Sokoban_Restart);
        }

        private void OnClick_Btn_MenuBtn()
        {
            // GameEvent.Send(UIEventID.Sokoban_Menu);
        }

        #endregion

        public void OnClose()
        {
            Close();
        }

        private void OnClick_Btn_LeftBtn()
        {
            // GameEvent.Send(UIEventID.Sokoban_Move, Vector2Int.left);
        }

        private void OnClick_Btn_DownBtn()
        {
            // GameEvent.Send(UIEventID.Sokoban_Move, Vector2Int.down);
        }

        private void OnClick_Btn_UpBtn()
        {
            // GameEvent.Send(UIEventID.Sokoban_Move, Vector2Int.up);
        }

        private void OnClick_Btn_RightBtn()
        {
            // GameEvent.Send(UIEventID.Sokoban_Move, Vector2Int.right);
        }
    }
}