using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    public class UI_VideoData
    {
        public RenderTexture _RenderTexture;
    }

    [Window(UILayer.Bottom)]
    class UI_Video : UIWindow
    {
        #region 脚本工具生成的代码
        private RawImage _RImg_Video;
        public override void ScriptGenerator()
        {
            _RImg_Video = FindChildComponent<RawImage>("_RImg_Video");
        }
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            _RImg_Video.texture = (UserData as UI_VideoData)._RenderTexture;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            // GameEvent.Send(UIEventID.PauseVideo);
            Log.Info("UI_Video 已销毁");
        }

        #region 事件
        #endregion

    }
}