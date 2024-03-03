using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Menu : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _Btn_Sokoban;
        public override void ScriptGenerator()
        {
            _Btn_Sokoban = FindChildComponent<Button>("_Btn_Sokoban");
            _Btn_Sokoban.onClick.AddListener(OnClick_Btn_SokobanBtn);
        }
        #endregion

        #region 事件

        private void OnClick_Btn_SokobanBtn()
        {
            GameEvent.Send(UIEvent.Sokoban_StartGame);
            Close();
        }

        #endregion
    }
}