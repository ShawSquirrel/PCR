﻿using System;
using System.Collections.Generic;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SkillSystem : Core.System
    {
        private Dictionary<TSkillType, ASKill> ASKills = new Dictionary<TSkillType, ASKill>();
        public float _SkillTime { get; private set; }

        public override void Create()
        {
            base.Create();
        }

        public override void Init()
        {
            base.Init();
            Utility.Unity.AddUpdateListener(Update);

            _SkillTime = 0;
        }

        private void Update()
        {
            _SkillTime += Time.deltaTime;
        }

        public override void Release()
        {
            base.Release();
            Utility.Unity.RemoveUpdateListener(Update);
            foreach (var (key, value) in ASKills)
            {
                value.Release();
                value.Destroy();
            }
            ASKills.Clear();
        }

        public override void Destroy()
        {
            base.Destroy();
        }


        public void CreateSkill(TSkillType skillType)
        {
            switch (skillType)
            {
                case TSkillType.Sword:
                    ASKills.Add(skillType, new SwordSkillController());
                    break;
                case TSkillType.Staff:
                    break;
                case TSkillType.Bow:
                    break;
            }
        }
        
    }
}