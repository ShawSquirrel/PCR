using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    public class UI_LevelData
    {
        public int _ExpMax;
        public int _CurExp;
        public int _Level;
    }
    [Window(UILayer.UI)]
    class UI_Level : UIWindow
    {
        #region 脚本工具生成的代码
        private Slider _Slider_Exp;
        private TextMeshProUGUI _TMP_Level;
        private TextMeshProUGUI _TMP_Exp;
        public override void ScriptGenerator()
        {
            _Slider_Exp = FindChildComponent<Slider>("_Slider_Exp");
            _TMP_Level = FindChildComponent<TextMeshProUGUI>("_Slider_Exp/Level/_TMP_Level");
            _TMP_Exp = FindChildComponent<TextMeshProUGUI>("_Slider_Exp/_TMP_Exp");
        }
        
        #endregion

        public override void OnCreate()
        {
            base.OnCreate();
            UI_LevelData data = UserData as UI_LevelData;
            _TMP_Exp.text = $"{data._CurExp}/{data._ExpMax}";
            _TMP_Level.text = $"{data._Level}";
            _Slider_Exp.value = data._CurExp * 1.0f / data._ExpMax;
        }
    }
}