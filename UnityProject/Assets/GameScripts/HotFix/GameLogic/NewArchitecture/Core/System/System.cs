using UnityEngine;
using NotImplementedException = System.NotImplementedException;

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

        public virtual void InitUnit(Transform parent = null, string name = "")
        {
            Unit = new Unit(parent, name);
        }

        public virtual void Init()
        {
        }

        public virtual void Release()
        {
        }
    }
}