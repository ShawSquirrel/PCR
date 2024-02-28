using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Menu : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _Btn_PushBox;
        public override void ScriptGenerator()
        {
            _Btn_PushBox = FindChildComponent<Button>("Image/_Btn_PushBox");
            _Btn_PushBox.onClick.AddListener(OnClick_Btn_PushBoxBtn);
        }
        #endregion

        #region 事件
        private void OnClick_Btn_PushBoxBtn()
        {
            GameEvent.Send(UIEvent.StartGameEventID);
        }
        #endregion

    }
}