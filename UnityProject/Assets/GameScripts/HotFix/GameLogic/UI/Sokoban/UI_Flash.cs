using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.Top)]
    class UI_Flash : UIWindow
    {
        #region 脚本工具生成的代码
        private Image _Img_Bg;
        public override void ScriptGenerator()
        {
            _Img_Bg = FindChildComponent<Image>("_Img_Bg");
        }
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _Img_Bg.material = UserData as Material;
        }

        #region 事件
        #endregion

    }
}