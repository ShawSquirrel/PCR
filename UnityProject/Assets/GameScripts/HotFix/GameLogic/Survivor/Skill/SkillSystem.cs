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
        private Dictionary<SkillType, ISkill> _dict_Skill = new Dictionary<SkillType, ISkill>();


        #region Start Release

        public void Start()
        {
            Utility.Unity.AddUpdateListener(Update);
            LoadConfigs();
            AddListen();
            CreateSkill();
        }

        public void Release()
        {
            Utility.Unity.RemoveUpdateListener(Update);
            ReleaseConfigs();
            RemoveListen();
            RemoveSkill();
        }

        #endregion


        #region Configs

        private void ReleaseConfigs()
        {
            _dict_SkillAttribute.Clear();
        }

        private void LoadConfigs()
        {
            _dict_SkillAttribute.Clear();
            foreach (SSkill2Attribute skill2Attribute in ConfigSystem.Instance.Tables.SSkillAttribute.DataList)
            {
                SkillAttribute attribute;
                if (_dict_SkillAttribute.TryGetValue(skill2Attribute.Type, out attribute) == false)
                {
                    attribute                                  = new SkillAttribute();
                    _dict_SkillAttribute[skill2Attribute.Type] = attribute;
                }

                switch (skill2Attribute.Kind)
                {
                    case SkillKind.Base:
                    {
                        attribute._SkillData = new SkillData
                                               {
                                                   _Atk           = skill2Attribute.Atk,
                                                   _Angle         = skill2Attribute.Area,
                                                   _CD            = skill2Attribute.Cd,
                                                   _SkillDescribe = skill2Attribute.Describe,
                                                   _Title         = skill2Attribute.Title,
                                               };
                    }
                        break;
                    case SkillKind.Upgrade:
                    {
                        attribute._List_SkillUpgradeObtained   ??= new List<SkillUpgrade>();
                        attribute._List_SkillUpgradeNoObtained ??= new List<SkillUpgrade>();
                        attribute._List_SkillUpgradeNoObtained.Add(new SkillUpgrade
                                                                   {
                                                                       _Atk                  = skill2Attribute.Atk,
                                                                       _Angle                = skill2Attribute.Area,
                                                                       _CD                   = skill2Attribute.Cd,
                                                                       _SkillUpgradeDescribe = skill2Attribute.Describe,
                                                                       _Title                = skill2Attribute.Title,
                                                                       _ID                   = skill2Attribute.Id
                                                                   });
                    }
                        break;
                }
            }
        }

        #endregion

        #region Listen

        private void AddListen()
        {
            GameEvent.AddEventListener<UI_UpgradeData>(UIEventID_Survivor.UpgradeSkill, UpgradeSkill);
        }


        private void RemoveListen()
        {
            GameEvent.RemoveEventListener<UI_UpgradeData>(UIEventID_Survivor.UpgradeSkill, UpgradeSkill);
        }

        private void UpgradeSkill(UI_UpgradeData data)
        {
            GameModule.UI.CloseWindow<UI_Upgrade>();
            SkillAttribute attribute = _dict_SkillAttribute[data._Type];
            SkillUpgrade skillUpgrade = attribute._List_SkillUpgradeNoObtained.Find(a => a._ID == data._ID);
            attribute._List_SkillUpgradeNoObtained.Remove(skillUpgrade);
            attribute._List_SkillUpgradeObtained.Add(skillUpgrade);
            
            
            GameEvent.Send(EventID_Survivor.Survivor_RefreshSkill);
        }

        #endregion


        private void Update()
        {
            UpdateSkillTowards();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                List<UI_UpgradeData> datas = new List<UI_UpgradeData>();
                SkillAttribute attribute = _dict_SkillAttribute[SkillType.Sword];
                int level = attribute._List_SkillUpgradeObtained.Count + 1;
                foreach (SkillUpgrade upgrade in attribute._List_SkillUpgradeNoObtained)
                {
                    datas.Add(new UI_UpgradeData
                              {
                                  _Title    = upgrade._Title,
                                  _Describe = upgrade._SkillUpgradeDescribe,
                                  _Level    = level,
                                  _ID       = upgrade._ID,
                                  _Type = SkillType.Sword
                              });
                }

                GameModule.UI.ShowUI<UI_Upgrade>(datas);
            }
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

        public void CreateSkill()
        {
            SwordSkill swordSkill = new SwordSkill();

            _dict_Skill[SkillType.Sword] = swordSkill;
        }
        public void RemoveSkill()
        {
            foreach (var (key, value) in _dict_Skill)
            {
                value.Release();
            }
            _dict_Skill.Clear();
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

        #region UpdateSkillTowards

        public void CloseUpdateSkillTowards()
        {
            _isUpdateCharacterSkillTowards = false;
        }

        public void OpenUpdateSkillTowards()
        {
            _isUpdateCharacterSkillTowards = true;
        }

        #endregion
    }
}