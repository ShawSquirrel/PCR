using System;
using System.Collections.Generic;
using GameConfig;
using TEngine;
using UnityEngine;

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

        public override void AddListen()
        {
            base.AddListen();
            GameEvent.AddEventListener<IItem>(EventID_Survivor.Survivor_UsingItem, UsingItem);
        }

        public override void RemoveListen()
        {
            base.RemoveListen();
            GameEvent.RemoveEventListener<IItem>(EventID_Survivor.Survivor_UsingItem, UsingItem);
        }

        public override void Start()
        {
            AddListen();
        }


        public override void Release()
        {
            RemoveListen();
            foreach (IItem item in _list_Item)
            {
                item.Release();
            }

            _list_Item.Clear();
        }


        public void CreateItem(TItemType itemType, Vector3 pos)
        {
            IItem item = GetItem(itemType, pos);
            _list_Item.Add(item);
        }

        public void UsingItem(IItem item)
        {
        }

        private IItem GetItem(TItemType itemType, Vector3 pos)
        {
            IItem item = null;
            switch (itemType)
            {
                case TItemType.ExpBall1:
                    item = new ExpBall(pos);
                    break;
            }

            return item;
        }
    }
}