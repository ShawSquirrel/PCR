using GameConfig;
using TEngine;

namespace GameLogic.Survivor
{
    public class Skill : ISkill
    {
        public bool _IsDestroy = false;
        public bool _IsRunning;


        protected SkillType _skillType;
        public Skill()
        {
            Utility.Unity.AddUpdateListener(Update);
            Utility.Unity.AddDestroyListener(Destroy);
        }

        protected virtual void Destroy()
        {
            _IsDestroy = true;
            Utility.Unity.RemoveUpdateListener(Update);
        }

        protected virtual void Update()
        {
        }

        public virtual void Run()
        {
        }

        public virtual void Release()
        {
            Utility.Unity.RemoveUpdateListener(Update);
            Log.Info("Parent Release");
        }
    }
}