using TEngine;
using UnityEngine.UI;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_SokobanSuccess : UIWindow
    {
        #region 脚本工具生成的代码

        private Button _Btn_Close;
        private Button _Btn_ReStart;
        private Button _Btn_Next;

        public override void ScriptGenerator()
        {
            _Btn_Close   = FindChildComponent<Button>("_Btn_Close");
            _Btn_ReStart = FindChildComponent<Button>("_Btn_ReStart");
            _Btn_Next    = FindChildComponent<Button>("_Btn_Next");
            _Btn_Close.onClick.AddListener(OnClick_Btn_CloseBtn);
            _Btn_ReStart.onClick.AddListener(OnClick_Btn_ReStartBtn);
            _Btn_Next.onClick.AddListener(OnClick_Btn_NextBtn);
        }

        #endregion

        #region 事件

        private void OnClick_Btn_CloseBtn()
        {
            GameEvent.Send(UIEventID.Sokoban_Menu);
            Close();
        }

        private void OnClick_Btn_ReStartBtn()
        {
            GameEvent.Send(UIEventID.Sokoban_Restart);
            Close();
        }

        private void OnClick_Btn_NextBtn()
        {
            GameEvent.Send(UIEventID.Sokoban_NextLevel);
            Close();
        }

        #endregion

    }
}