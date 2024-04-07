using GameLogic.NewArchitecture.Game.Survivor;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Result : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _Btn_Menu;
        public override void ScriptGenerator()
        {
            _Btn_Menu = FindChildComponent<Button>("Image/_Btn_Menu");
            _Btn_Menu.onClick.AddListener(OnClick_Btn_MenuBtn);
        }
        #endregion

        private void OnClick_Btn_MenuBtn()
        {
            GameEvent.Send(EventID.ReturnMenu);
        }

    }
}