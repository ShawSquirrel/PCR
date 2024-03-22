using TEngine;

namespace GameLogic.Survivor
{
    public class Skill : ISkill
    {
        public bool _IsDestroy = false;
        public bool _IsRunning;
        public float _Atk;
        public float _CD;
        public float _Scale;

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
    }
}