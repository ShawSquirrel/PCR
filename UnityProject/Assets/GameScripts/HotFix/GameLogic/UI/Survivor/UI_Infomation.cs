using GameLogic.NewArchitecture.Game.Survivor;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UI_Infomation : UIWindow
    {
        #region 脚本工具生成的代码
        private Slider _Slider_Blood;
        public override void ScriptGenerator()
        {
            _Slider_Blood = FindChildComponent<Slider>("Group_Player_Info/Player_Bg/_Slider_Blood");
        }
        #endregion
        public override void OnCreate()
        {
            base.OnCreate();
            GameEvent.AddEventListener<float>(EventID.SetBloodID, SetBlood);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            GameEvent.RemoveEventListener<float>(EventID.SetBloodID, SetBlood);
        }

        private void SetBlood(float percent)
        {
            _Slider_Blood.value = percent;
        }

    }
}