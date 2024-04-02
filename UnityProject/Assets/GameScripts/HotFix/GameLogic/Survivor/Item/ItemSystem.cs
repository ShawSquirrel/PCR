using System.Collections.Generic;

namespace GameLogic.Survivor
{
    public class ItemSystem : GameBase.System
    {
        private List<IItem> _list_Item;

        public override void Awake()
        {
            base.Awake();
            _list_Item = new List<IItem>();
        }

        public override void Start()
        {
        }


        public override void Release()
        {
        }
    }
}