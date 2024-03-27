using TEngine;
using UnityEngine;

namespace GameBase
{
    public class System
    {
        public GameRoot _GameRoot;
        public GameObject _Obj;
        public Transform _TF;

        public System()
        {
            
        }

        public virtual void Awake()
        {
            // AddListen();
        }

        public virtual void OnDestroy()
        {
            // Removelisten();
        }

        public virtual void OnReset()
        {
        }

        public virtual void Init()
        {
            
        }
        //
        // public virtual void AddListen()
        // {
        // }
        //
        // public virtual void Removelisten()
        // {
        // }
    }
}