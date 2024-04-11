using System.Collections.Generic;
using GameBase;
using GameConfig;
using GameLogic.NewArchitecture.Core;
using GameLogic.NewArchitecture.Game.Survivor;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    public struct UI_SelectCharacterData
    {
        public Sprite _Sprite;
        public TCharacterType _CharacterID;
    }
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
            // _Toggle_Item.onValueChanged.AddListener(OnToggle_Toggle_ItemChange);
            _Btn_Close.onClick.AddListener(OnClick_Btn_CloseBtn);
        }
        #endregion

        public override void OnRefresh()
        {
            base.OnRefresh();
            Transform root = _Toggle_Item.transform.parent;
            for (int i = 1; i < root.childCount; i++)
            {
                Object.Destroy(root.GetChild(i).gameObject);
            }
            List<UI_SelectCharacterData> userData = UserDatas[0] as List<UI_SelectCharacterData>;
            TCharacterType id = (TCharacterType)UserDatas[1];

            foreach (UI_SelectCharacterData characterData in userData)
            {
                
                Toggle item = Object.Instantiate(_Toggle_Item.gameObject, root).GetComponent<Toggle>();
                item.gameObject.SetActive(true);
                item.onValueChanged.AddListener((isOn) => OnToggle_Toggle_ItemChange(isOn, characterData._CharacterID));

                item.SetIsOnWithoutNotify(id == characterData._CharacterID);
            }

        }

        #region 事件
        private void OnToggle_Toggle_ItemChange(bool isOn, TCharacterType id)
        {
            if (isOn)
            {
                GameEvent.Send(EventID.SelectCharacter, id);
            }
        }
        private void OnClick_Btn_CloseBtn()
        {
            GameEvent.Send(EventID.CloseSelectCharacterPanel);
        }
        #endregion

    }
}