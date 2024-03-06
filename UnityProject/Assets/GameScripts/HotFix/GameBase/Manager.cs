using UnityEngine;

namespace GameBase
{
    public class Manager
    {
        public GameRoot _GameRoot;
        public GameObject _Obj;
        public Transform _TF;


        public virtual void Awake()
        {
            Addlisten();
        }
        public virtual void OnDestroy()
        {
            Removelisten();
        }
        public virtual void OnReset()
        {
            
        }

        public virtual void Init()
        {
            
        }

        public virtual void Addlisten()
        {
            
        }
        public virtual void Removelisten()
        {
            
        }
        
        
    }
}