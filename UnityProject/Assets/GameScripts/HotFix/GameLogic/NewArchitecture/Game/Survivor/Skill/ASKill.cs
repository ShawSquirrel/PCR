using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;
using Utility = TEngine.Utility;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public abstract class ASKill : ISkill
    {
        protected Unit _unit;
        protected float _time => SurvivorRoot.Instance.GetSystem<SkillSystem>()._SkillTime;
        protected float _lastRunTime;

        public ASKill()
        {
            Awake();
            Init();
        }
        
        protected virtual void InitUnit(string prefabName)
        {
            
        }
        public virtual void Init()
        {
            Utility.Unity.AddUpdateListener(Update);
            Utility.Unity.AddFixedUpdateListener(FixedUpdate);
        }

        public virtual void Release()
        {
            Utility.Unity.RemoveUpdateListener(Update);
            Utility.Unity.RemoveFixedUpdateListener(FixedUpdate);
        }

        public virtual void Run()
        {
        }

        public virtual void Awake()
        {
        }

        public virtual void Destroy()
        {
            _unit.Destroy();
            _unit = null;
        }

        public virtual void Update()
        {
            
        }

        public virtual void FixedUpdate()
        {
        }
    }
}