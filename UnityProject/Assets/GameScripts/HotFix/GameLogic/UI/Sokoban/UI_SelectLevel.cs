using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_SelectLevel : UIWindow
    {
        #region 脚本工具生成的代码
        private Button _Btn_LevelItem;
        public override void ScriptGenerator()
        {
            _Btn_LevelItem = FindChildComponent<Button>("Bg/_Btn_LevelItem");
        }
        #endregion


    }
}