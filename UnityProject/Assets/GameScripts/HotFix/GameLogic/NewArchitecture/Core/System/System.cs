using UnityEngine;

namespace GameLogic.NewArchitecture.Core
{
    public abstract class System : ISystem
    {
        public Unit Unit { get; private set; }

        public virtual void Awake()
        {
        }

        public virtual void Destroy()
        {
        }


        public virtual void Init()
        {
        }

        public virtual void Release()
        {
        }

        public virtual void InitUnit(Transform parent = null, string name = "")
        {
            Unit = new Unit(parent, name);
        }

        public virtual void DestroyUnit()
        {
            Unit.Destroy();
            Unit = null;
        }
    }
}