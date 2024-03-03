using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    public class UI_MenuData
    {
        public RenderTexture _RenderTexture;
    }
    [Window(UILayer.UI)]
    class UI_Menu : UIWindow
    {
        #region 脚本工具生成的代码
        private RawImage _RImg_Video;
        private Button _Btn_Sokoban;
        public override void ScriptGenerator()
        {
            _RImg_Video  = FindChildComponent<RawImage>("_RImg_Video");
            _Btn_Sokoban = FindChildComponent<Button>("_Btn_Sokoban");
            _Btn_Sokoban.onClick.AddListener(OnClick_Btn_SokobanBtn);
        }
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _RImg_Video.texture = (UserData as UI_MenuData)._RenderTexture;
        }

        #region 事件

        private void OnClick_Btn_SokobanBtn()
        {
            GameEvent.Send(UIEvent.Sokoban_StartGame);
            Close();
        }

        #endregion
    }
}