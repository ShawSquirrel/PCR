using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_SelectCharacter : UIWindow
    {
        #region 脚本工具生成的代码
        private Toggle _Toggle_Item;
        private Button _Btn_Close;
        public override void ScriptGenerator()
        {
            _Toggle_Item = FindChildComponent<Toggle>("Popup/Flags/_Toggle_Item");
            _Btn_Close   = FindChildComponent<Button>("Popup/_Btn_Close");
            _Toggle_Item.onValueChanged.AddListener(OnToggle_Toggle_ItemChange);
            _Btn_Close.onClick.AddListener(OnClick_Btn_CloseBtn);
        }
        #endregion

        #region 事件
        private void OnToggle_Toggle_ItemChange(bool isOn)
        {
        }
        private void OnClick_Btn_CloseBtn()
        {
        }
        #endregion

    }
}