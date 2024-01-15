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
        private Button _BTN_Level1;
        private Button _BTN_Level2;
        public override void ScriptGenerator()
        {
            _BTN_Start  = FindChildComponent<Button>("BtnGroup/_BTN_Start");
            _BTN_Level1 = FindChildComponent<Button>("BtnGroup/_BTN_Level1");
            _BTN_Level2 = FindChildComponent<Button>("BtnGroup/_BTN_Level2");
            _BTN_Start.onClick.AddListener(OnClick_BTN_StartBtn);
            _BTN_Level1.onClick.AddListener(OnClick_BTN_Level1Btn);
            _BTN_Level2.onClick.AddListener(OnClick_BTN_Level2Btn);
        }
        #endregion

        #region 事件
        private void OnClick_BTN_StartBtn()
        {
            _BTN_Level1.gameObject.SetActive(true);
            _BTN_Level2.gameObject.SetActive(true);
        }
        private void OnClick_BTN_Level1Btn()
        {
            GameEvent.Send(UIEvent.StartGameID);
            Close();
        }
        private void OnClick_BTN_Level2Btn()
        {
        }
        #endregion

    }
}