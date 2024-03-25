using System;
using System.Collections.Generic;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SkillSystem : GameBase.System
    {
        private float _angle;
        private bool _isUpdateCharacterSkillTowards;
        public float Angle => _angle;
        private Dictionary<SkillType, SkillAttribute> _dict_SkillAttribute = new Dictionary<SkillType, SkillAttribute>();

        public override void Awake()
        {
            base.Awake();
            Utility.Unity.AddUpdateListener(Update);
            LoadConfigs();
        }

        private void LoadConfigs()
        {
            _dict_SkillAttribute.Clear();
            foreach (SSkill2Attribute skill2Attribute in ConfigSystem.Instance.Tables.SSkillAttribute.DataList)
            {
                SkillAttribute attribute;
                if (_dict_SkillAttribute.TryGetValue(skill2Attribute.Type, out attribute) == false)
                {
                    attribute = new SkillAttribute();
                    _dict_SkillAttribute[skill2Attribute.Type] = attribute;
                }

                switch (skill2Attribute.Kind)
                {
                    case SkillKind.Base:
                    {
                        attribute._SkillData = new SkillData
                        {
                            _Atk = skill2Attribute.Atk,
                            _Angle = skill2Attribute.Area,
                            _CD = skill2Attribute.Cd,
                            _SkillDescribe = skill2Attribute.Describe
                        };
                    }
                        break;
                    case SkillKind.Upgrade:
                    {
                        attribute._List_SkillUpgrade ??= new List<SkillUpgrade>();
                        attribute._List_SkillUpgrade.Add(new SkillUpgrade
                        {
                            _Atk = skill2Attribute.Atk,
                            _Angle = skill2Attribute.Area,
                            _CD = skill2Attribute.Cd,
                            _SkillUpgradeDescribe = skill2Attribute.Describe
                        });
                    }
                        break;
                }
            }
        }

        private void Update()
        {
            UpdateSkillTowards();
        }

        private void UpdateSkillTowards()
        {
            if (_isUpdateCharacterSkillTowards == false) return;
            Vector2 mouse = Input.mousePosition;
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 vectorToConvert = (mouse - center).normalized;
            // 计算向量的极坐标角度（以弧度为单位）
            float angleRadians = Mathf.Atan2(vectorToConvert.y, vectorToConvert.x);

            // 将弧度转换为角度
            _angle = angleRadians * Mathf.Rad2Deg;
        }

        public void CreateSkill(string skillName)
        {
            SwordSkill swordSkill = new SwordSkill();
        }

        public SkillAttribute GetSkillBySkillType(SkillType skillType)
        {
            if (_dict_SkillAttribute.TryGetValue(skillType, out SkillAttribute attribute) == false)
            {
                Log.Error("No this Skill Type...");
                return null;
            }

            return attribute;
        }

        public void CloseUpdateSkillTowards()
        {
            _isUpdateCharacterSkillTowards = false;
        }
        public void OpenUpdateSkillTowards()
        {
            _isUpdateCharacterSkillTowards = true;
        }
    }
}