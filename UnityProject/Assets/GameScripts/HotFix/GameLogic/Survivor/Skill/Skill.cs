using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class Skill : ISkill
    {
        public bool _IsDestroy = false;
        public bool _IsRunning;
        public SkillAttribute _SkillAttribute;
        public SkillData _BaseData;

        protected SkillType _skillType;

        public Skill()
        {
            Utility.Unity.AddUpdateListener(Update);
            Utility.Unity.AddDestroyListener(Destroy);

            GameEvent.AddEventListener(EventID_Survivor.Survivor_RefreshSkill, Refresh);
        }

        protected virtual void Refresh()
        {
        }

        protected virtual void Destroy()
        {
            _IsDestroy = true;
            Utility.Unity.RemoveUpdateListener(Update);
            GameEvent.RemoveEventListener(EventID_Survivor.Survivor_RefreshSkill, Refresh);
        }

        protected virtual void Update()
        {
        }

        public virtual void Run()
        {
        }

        public virtual void Release()
        {
            _IsDestroy = true;
            Utility.Unity.RemoveUpdateListener(Update);
            Log.Info("Parent Release");
        }
    }
}