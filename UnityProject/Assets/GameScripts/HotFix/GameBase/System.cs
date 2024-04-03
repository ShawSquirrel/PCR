using TEngine;
using UnityEngine;

namespace GameBase
{
    public class System
    {
        protected GameRoot _root;
        protected bool _isRelease;
        public GameRoot _GameRoot;
        public GameObject _Obj;
        public Transform _TF;

        public System()
        {
            
        }

        public virtual void Awake()
        {
        }

        public virtual void OnDestroy()
        {
        }
        public virtual void AddListen()
        {
        }

        public virtual void RemoveListen()
        {
        }
        

        public virtual void OnReset()
        {
        }

        public virtual void Init()
        {
            
        }
        
        public virtual void Start()
        {
        }
        
        public virtual void Release()
        {
        }
    }
}