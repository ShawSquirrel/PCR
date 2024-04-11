using System.Collections.Generic;
using GameConfig;
using GameLogic.Survivor;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    public class UI_UpgradeData
    {
        public string _Title;
        public string _Describe;
        public int _Level;
        public int _ID;
        public TSkillType _Type;
    }

    [Window(UILayer.UI)]
    class UI_Upgrade : UIWindow
    {
        #region 脚本工具生成的代码

        private Transform _TF_Root;
        private Button _Btn_Item;

        public override void ScriptGenerator()
        {
            _TF_Root  = FindChild("Scroll View/Viewport/_TF_Root");
            _Btn_Item = FindChildComponent<Button>("Scroll View/Viewport/_TF_Root/_Btn_Item");
        }

        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            List<UI_UpgradeData> datas = UserData as List<UI_UpgradeData>;
            foreach (UI_UpgradeData data in datas)
            {
                Transform item = Object.Instantiate(_Btn_Item.gameObject, _TF_Root).transform;
                item.gameObject.SetActive(true);
                item.Find("Describe").GetComponent<TextMeshProUGUI>().text = data._Describe;
                item.Find("Title").GetComponent<TextMeshProUGUI>().text    = data._Title;
                SetStarLevel(item, data._Level);
                // TODO:设置ICON

                item.GetComponent<Button>().onClick.AddListener(() => OnClickEvent(data));
            }
        }

        private void SetStarLevel(Transform item, int level)
        {
            Transform starParent = item.Find("Stars");
            for (int i = 0; i < level; i++)
            {
                starParent.GetChild(i).Find("Active").gameObject.SetActive(true);
            }
        }


        private void OnClickEvent(UI_UpgradeData data)
        {
            GameEvent.Send(UIEventID_Survivor.UpgradeSkill, data);
        }
    }
}