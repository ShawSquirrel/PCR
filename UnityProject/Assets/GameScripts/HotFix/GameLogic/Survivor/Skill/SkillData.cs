using System.Collections.Generic;

namespace GameLogic.Survivor
{
    public class SkillData
    {
        public float _Atk;
        public float _Angle;
        public float _CD;
        public string _SkillDescribe;
        public string _Title;
    }
    public class SkillUpgrade
    {
        public int _ID;
        public float _Atk;
        public float _Angle;
        public float _CD;
        public string _SkillUpgradeDescribe;
        public string _Title;
    }
    
    public class SkillAttribute
    {
        public SkillData _SkillData;
        public List<SkillUpgrade> _List_SkillUpgradeObtained;
        public List<SkillUpgrade> _List_SkillUpgradeNoObtained;
    }
}