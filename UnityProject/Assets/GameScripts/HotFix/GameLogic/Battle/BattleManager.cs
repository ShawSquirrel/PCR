using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class BattleItem
    {
        public bool _IsAttacker;
    }

    public class BattleManager : Entity
    {
        public Character _Attacker;
        public Character _Attacked;

        public Queue<BattleItem> _BattleQueue = new Queue<BattleItem>();

        protected override void Awake()
        {
            base.Awake();
            LevelManager.Instance._BattleManager = this;
            _TF.SetParent(LevelManager.Instance._Root);
        }


        public void InitBattle(Character attacker, Character attacked)
        {
            _Attacker = attacker;
            _Attacked = attacked;


            int speedAttacker = _Attacker._Attribute.Constant._SpeedValue;
            int speedAttacked = _Attacked._Attribute.Constant._SpeedValue;

            _BattleQueue.Clear();
            switch (speedAttacker - speedAttacked)
            {
                case < 0:
                {
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                }
                    break;
                case > 0:
                {
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                }
                    break;
                default:
                {
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _BattleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                }
                    break;
            }
        }

        public void PlayBattle()
        {
            while (_BattleQueue.Count != 0)
            {
                bool isAttacker = _BattleQueue.Dequeue()._IsAttacker;
                if (isAttacker)
                {
                    Debug.Log($"{_Attacker.name}攻击了{_Attacked.name}");
                }
                else
                {
                    Debug.Log($"{_Attacked.name}攻击了{_Attacker.name}");
                }
            }
        }
    }
}