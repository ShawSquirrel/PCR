using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using Object = UnityEngine.Object;

namespace GameLogic
{
    public class Class_ActionBarItem
    {
        public Transform _TF;
        public Sprite _Sprite_Img;
        public float _Float_Speed;
        public float _Float_Percent;
        public string _Str_CharacterName;
    }

    [Window(UILayer.UI)]
    class UI_ActionBar : UIWindow
    {
        private Dictionary<string, Class_ActionBarItem> _dict_ActionBarItem;

        private bool _bool_IsPause = false;

        #region 脚本工具生成的代码

        private Image _Img_Bg;
        private Transform _TF_Head;

        public override void ScriptGenerator()
        {
            _Img_Bg  = FindChildComponent<Image>("_Img_Bg");
            _TF_Head = FindChild("_Img_Bg/_TF_Head");
        }

        #endregion

        #region 事件

        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _dict_ActionBarItem = new Dictionary<string, Class_ActionBarItem>();
        }

        public void AddActionBarItem(string characterName, Sprite img, float speed, float percent)
        {
            GameObject obj = Object.Instantiate(_TF_Head.gameObject, _Img_Bg.transform, true);
            obj.SetActive(true);
            obj.name = characterName;

            Class_ActionBarItem item = new Class_ActionBarItem()
                                       {
                                           _TF            = obj.transform,
                                           _Sprite_Img    = img,
                                           _Float_Speed   = speed,
                                           _Float_Percent = percent,
                                           _Str_CharacterName =  characterName
                                       };
            _dict_ActionBarItem.Add(characterName, item);
        }


        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_bool_IsPause) return;

            foreach (Class_ActionBarItem item in _dict_ActionBarItem.Values)
            {
                if (Math.Abs(item._Float_Percent - 100) < 0.001f)
                {
                    _bool_IsPause = true;
                    GameEvent.Send(UIEvent.CharacterActionEventID, item._Str_CharacterName);
                }
            }

            foreach (Class_ActionBarItem item in _dict_ActionBarItem.Values)
            {
                item._Float_Percent = Mathf.Clamp(item._Float_Percent + item._Float_Speed * Time.deltaTime, 0, 100);

                Vector2 pos = ((RectTransform)item._TF).anchoredPosition;
                pos                                        = new Vector2(ReMap(item._Float_Percent), pos.y);
                ((RectTransform)item._TF).anchoredPosition = pos;
                Debug.Log(item._Float_Percent);
            }
        }

        public void ResetCharacterPercentByName(string characterName)
        {
            _dict_ActionBarItem[characterName]._Float_Percent = 0;
            _bool_IsPause                                     = false;
        }

        public float ReMap(float value)
        {
            return Remap(value, 0, 100f, 6.5f, 604.5f);
        }

        float Remap(float value, float from1, float to1, float from2, float to2)
        {
            // 使用Mathf.Lerp进行重新映射
            float normalizedValue = Mathf.InverseLerp(from1, to1, value);
            float remappedValue = Mathf.Lerp(from2, to2, normalizedValue);

            return remappedValue;
        }
    }
}