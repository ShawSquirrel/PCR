using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    public class Class_ActionBarItem
    {
        public Transform _TF;
        public Sprite _Sprite_Img;
        public float _Float_Speed;
        public float _Float_Percent;
    }

    [Window(UILayer.UI)]
    class UI_ActionBar : UIWindow
    {
        private List<Class_ActionBarItem> _list_Action;

        private float _float_Left = 6.5f;
        private float _float_Right = 604.5f;

        #region 脚本工具生成的代码

        private Image _Img_Bg;
        private Transform _TF_Head;

        public override void ScriptGenerator()
        {
            _Img_Bg = FindChildComponent<Image>("_Img_Bg");
            _TF_Head = FindChild("_Img_Bg/_TF_Head");
        }

        #endregion

        #region 事件

        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _list_Action = new List<Class_ActionBarItem>();
        }

        public void AddActionBarItem(Sprite img, float speed, float percent)
        {
            GameObject obj = Object.Instantiate(_TF_Head.gameObject);
            obj.SetActive(true);
            // obj.GetComponent<Image>().sprite = img;
            _list_Action.Add(new Class_ActionBarItem
            {
                _TF = obj.transform,
                _Sprite_Img = img,
                _Float_Speed = speed,
                _Float_Percent = percent
            });
        }


        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (Class_ActionBarItem item in _list_Action)
            {
                item._Float_Percent = Mathf.Repeat(item._Float_Percent + item._Float_Speed * Time.deltaTime, 100);

                Vector2 pos = ((RectTransform)item._TF).anchoredPosition;
                Debug.Log(pos);
            }
            
            
        }

        public float ReMap(float value)
        {
            return Remap(value, 6.5f, 0, 604.5f, 100f);
        }

        private float Remap(float value, float from1, float to1, float from2, float to2)
        {
            // 将输入值归一化到[0, 1]范围
            float normalizedValue = (value - from1) / (to1 - from1);

            // 将归一化值重新映射到目标范围
            float remappedValue = normalizedValue * (to2 - from2) + from2;

            return remappedValue;
        }
        
    }
}