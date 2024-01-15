using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Menu : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _BTN_Start;
        public override void ScriptGenerator()
        {
            _BTN_Start = FindChildComponent<Button>("_BTN_Start");
            _BTN_Start.onClick.AddListener(OnClick_BTN_StartBtn);
        }
        #endregion

        #region 事件
        private void OnClick_BTN_StartBtn()
        {
            GameEvent.Send(UIEvent.StartGameID);
            Close();
        }
        #endregion

    }
}