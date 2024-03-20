using TEngine;

namespace GameLogic.Survivor
{
    public class Skill
    {
        public bool _IsRunning;
        public float _Atk;
        public float _CD;
        public float _Scale;

        public Skill()
        {
            Utility.Unity.AddUpdateListener(Update);
        }

        protected virtual void Update()
        {
        }

        public virtual void Run()
        {
        }
    }
}