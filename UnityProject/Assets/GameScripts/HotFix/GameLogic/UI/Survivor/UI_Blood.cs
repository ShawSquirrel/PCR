using GameLogic.Survivor;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Blood : UIWindow
    {
        #region 脚本工具生成的代码
        private Image _Img_Blood;
        public override void ScriptGenerator()
        {
            _Img_Blood = FindChildComponent<Image>("Image/_Img_Blood");
        }
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            GameEvent.AddEventListener<float>(UIEventID_Survivor.SetBlood, SetBlood);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            GameEvent.RemoveEventListener<float>(UIEventID_Survivor.SetBlood, SetBlood);
        }

        private void SetBlood(float percent)
        {
            _Img_Blood.fillAmount = percent;
        }

    }
}