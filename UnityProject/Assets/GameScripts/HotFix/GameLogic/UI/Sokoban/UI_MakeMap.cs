using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_MakeMap : UIWindow
    {
        #region 脚本工具生成的代码

        private Transform _TF_Root;
        private Button _Btn_Revert;
        private Button _Btn_Save;
        private Button _Btn_Close;

        public override void ScriptGenerator()
        {
            _TF_Root    = FindChild("_TF_Root");
            _Btn_Revert = FindChildComponent<Button>("_Btn_Revert");
            _Btn_Save   = FindChildComponent<Button>("_Btn_Save");
            _Btn_Close  = FindChildComponent<Button>("_Btn_Close");
            _Btn_Revert.onClick.AddListener(OnClick_Btn_RevertBtn);
            _Btn_Save.onClick.AddListener(OnClick_Btn_SaveBtn);
            _Btn_Close.onClick.AddListener(OnClick_Btn_CloseBtn);
        }

        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            for (int i = 0; i < _TF_Root.childCount; i++)
            {
                Toggle toggle = _TF_Root.GetChild(i).GetComponent<Toggle>();
                toggle.onValueChanged.AddListener(isOn => OnToggle_Toggle_0Change(isOn, toggle.name));
            }
        }

        private void OnToggle_Toggle_0Change(bool isOn, string name)
        {
            if (!_TF_Root.GetComponent<ToggleGroup>().AnyTogglesOn())
            {
                GameEvent.Send(UIEvent.Sokoban_MakeMapSelectType, 99);
                return;
            }

            if (isOn)
            {
                int type = int.Parse(name);

                GameEvent.Send(UIEvent.Sokoban_MakeMapSelectType, type);
            }
        }

        private void OnClick_Btn_CloseBtn()
        {
            Close();
        }

        private void OnClick_Btn_SaveBtn()
        {
            GameEvent.Send(UIEvent.Sokoban_MakeMapSave);
            Close();
        }

        private void OnClick_Btn_RevertBtn()
        {
            
        }
    }
}