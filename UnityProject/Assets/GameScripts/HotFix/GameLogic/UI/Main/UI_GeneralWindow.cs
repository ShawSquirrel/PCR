using System;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    public class UI_GeneralWindowData
    {
        public Action<string> OnConfirm;
        public Action OnCancel;
    }

    [Window(UILayer.UI)]
    class UI_GeneralWindow : UIWindow
    {
        private UI_GeneralWindowData _data;

        #region 脚本工具生成的代码

        private Button _Btn_Confirm;
        private Button _Btn_Cancel;
        private TMP_InputField _Input_LevelName;

        public override void ScriptGenerator()
        {
            _Btn_Confirm     = FindChildComponent<Button>("Bg/_Btn_Confirm");
            _Btn_Cancel      = FindChildComponent<Button>("Bg/_Btn_Cancel");
            _Input_LevelName = FindChildComponent<TMP_InputField>("Bg/_Input_LevelName");
            _Btn_Confirm.onClick.AddListener(OnClick_Btn_ConfirmBtn);
            _Btn_Cancel.onClick.AddListener(OnClick_Btn_CancelBtn);
        }

        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _data = UserData as UI_GeneralWindowData;
        }

        #region 事件

        private void OnClick_Btn_ConfirmBtn()
        {
            _data?.OnConfirm?.Invoke(_Input_LevelName.text);
            Close();
        }

        private void OnClick_Btn_CancelBtn()
        {
            _data?.OnCancel?.Invoke();
            Close();
        }

        #endregion
    }
}