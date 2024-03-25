using System.Collections.Generic;

namespace GameLogic.Survivor
{
    public class SkillData
    {
        public float _Atk;
        public float _Angle;
        public float _CD;
        public string _SkillDescribe;
    }
    public class SkillUpgrade
    {
        public float _Atk;
        public float _Angle;
        public float _CD;
        public string _SkillUpgradeDescribe;
    }
    
    public class SkillAttribute
    {
        public SkillData _SkillData;
        public List<SkillUpgrade> _List_SkillUpgrade;
    }
}