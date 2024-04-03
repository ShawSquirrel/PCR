using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class Item : IItem
    {
        public GameObject _Obj;
        public Transform _TF;

        public Item()
        {
            
        }
        
        
        public virtual void Using()
        {
            
        }

        public virtual void Moving()
        {
        }

        public void Release()
        {
            Object.Destroy(_Obj);
        }
    }
}