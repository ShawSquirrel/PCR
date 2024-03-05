using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_SurvivorMenu : UIWindow
    {
        #region 脚本工具生成的代码

        private Button _Btn_StartGame;
        private Button _Btn_Upgrade;
        private Button _Btn_Unlock;
        private Button _Btn_Option;
        private Button _Btn_Exit;

        public override void ScriptGenerator()
        {
            _Btn_StartGame = FindChildComponent<Button>("Bg/_Btn_StartGame");
            _Btn_Upgrade = FindChildComponent<Button>("Bg/_Btn_Upgrade");
            _Btn_Unlock = FindChildComponent<Button>("Bg/_Btn_Unlock");
            _Btn_Option = FindChildComponent<Button>("Bg/_Btn_Option");
            _Btn_Exit = FindChildComponent<Button>("Bg/_Btn_Exit");
            _Btn_StartGame.onClick.AddListener(OnClick_Btn_StartGameBtn);
            _Btn_Upgrade.onClick.AddListener(OnClick_Btn_UpgradeBtn);
            _Btn_Unlock.onClick.AddListener(OnClick_Btn_UnlockBtn);
            _Btn_Option.onClick.AddListener(OnClick_Btn_OptionBtn);
            _Btn_Exit.onClick.AddListener(OnClick_Btn_ExitBtn);
        }

        #endregion

        private void OnClick_Btn_StartGameBtn()
        {
            GameEvent.Send(SurvivorEvent.Survivor_StartGame);
        }

        private void OnClick_Btn_UpgradeBtn()
        {
        }

        private void OnClick_Btn_UnlockBtn()
        {
        }

        private void OnClick_Btn_OptionBtn()
        {
        }

        private void OnClick_Btn_ExitBtn()
        {
        }
    }
}