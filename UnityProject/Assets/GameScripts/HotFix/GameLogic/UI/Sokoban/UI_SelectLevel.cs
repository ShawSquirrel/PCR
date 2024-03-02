using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_SelectLevel : UIWindow
    {
        #region 脚本工具生成的代码

        private Button _Btn_MakeMap;
        private Transform _TF_Bg;
        private Button _Btn_LevelItem;

        public override void ScriptGenerator()
        {
            _Btn_MakeMap   = FindChildComponent<Button>("_Btn_MakeMap");
            _TF_Bg         = FindChild("_TF_Bg");
            _Btn_LevelItem = FindChildComponent<Button>("_TF_Bg/_Btn_LevelItem");
            _Btn_MakeMap.onClick.AddListener(OnClick_Btn_MakeMapBtn);
        }

        #endregion

        public void AddBtn(string name)
        {
            Button btn = Object.Instantiate(_Btn_LevelItem.gameObject, _TF_Bg).GetComponent<Button>();
            btn.gameObject.SetActive(true);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = name;
            btn.onClick.AddListener(() => SelectLevelByName(name));
        }

        private void OnClick_Btn_MakeMapBtn()
        {
            GameEvent.Send(UIEvent.Sokoban_MakeMap);
            Close();
        }

        private void SelectLevelByName(string name)
        {
            Log.Info(name);
            GameEvent.Send(UIEvent.Sokoban_SelectLevel, name);
            Close();
        }
    }
}