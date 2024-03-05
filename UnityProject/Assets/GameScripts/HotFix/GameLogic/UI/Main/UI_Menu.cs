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
        private Button _Btn_Survivor;

        public override void ScriptGenerator()
        {
            _Btn_Sokoban = FindChildComponent<Button>("Bg/_Btn_Sokoban");
            _Btn_Survivor = FindChildComponent<Button>("Bg/_Btn_Survivor");
            _Btn_Sokoban.onClick.AddListener(OnClick_Btn_SokobanBtn);
            _Btn_Survivor.onClick.AddListener(OnClick_Btn_SurvivorBtn);
        }

        #endregion


        private void OnClick_Btn_SokobanBtn()
        {
            GameEvent.Send(UIEvent.Sokoban_StartGame);
            Close();
        }

        private void OnClick_Btn_SurvivorBtn()
        {
            GameEvent.Send(SurvivorEvent.Survivor_StartGame);
        }
    }
}