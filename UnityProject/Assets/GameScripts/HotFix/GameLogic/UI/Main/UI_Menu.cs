using GameLogic.Survivor;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Menu : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _Btn_Sokoban;
        private Button _Btn_Survivor;
        private TextMeshProUGUI _TMP_Version;
        public override void ScriptGenerator()
        {
            _Btn_Sokoban  = FindChildComponent<Button>("Bg/_Btn_Sokoban");
            _Btn_Survivor = FindChildComponent<Button>("Bg/_Btn_Survivor");
            _TMP_Version  = FindChildComponent<TextMeshProUGUI>("_TMP_Version");
            _Btn_Sokoban.onClick.AddListener(OnClick_Btn_SokobanBtn);
            _Btn_Survivor.onClick.AddListener(OnClick_Btn_SurvivorBtn);
        }
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _TMP_Version.text = GameModule.Resource.GetPackageVersion();
        }


        private void OnClick_Btn_SokobanBtn()
        {
            GameEvent.Send(UIEventID.Sokoban_StartGame);
            Close();
        }

        private void OnClick_Btn_SurvivorBtn()
        {
            GameEvent.Send(EventID_Survivor.Survivor_StartGame);
        }
    }
}