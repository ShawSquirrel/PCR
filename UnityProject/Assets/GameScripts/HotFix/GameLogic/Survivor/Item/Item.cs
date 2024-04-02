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
        
        
        public virtual void PickUp()
        {
            Log.Info($"捡起了 {$"{_Obj.name}".SetColor(Color.green)}");
        }

        public virtual void Moving()
        {
        }
    }
}