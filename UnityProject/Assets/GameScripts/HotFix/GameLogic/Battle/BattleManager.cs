using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameConfig;
using TEngine;
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

        public Transform _AttackerPos;
        public Transform _AttackedPos;

        public AnimComponent _AttackerAnim;
        public AnimComponent _AttackedAnim;

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

            _AttackerAnim                   = GameModule.Resource.LoadAsset<GameObject>("优衣Body").GetComponent<AnimComponent>();
            _AttackerAnim._TF.localScale    = new Vector3(0.5f, 0.5f, 0.5f);
            _AttackerAnim._TF.SetParent(_AttackerPos);
            _AttackerAnim._TF.localPosition = Vector3.zero;

            _AttackedAnim                = GameModule.Resource.LoadAsset<GameObject>("镜华Body").GetComponent<AnimComponent>();
            _AttackedAnim._TF.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            _AttackedAnim._TF.SetParent(_AttackedPos);
            _AttackedAnim._TF.localPosition   = Vector3.zero;

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

        public async void PlayBattle()
        {
            while (_BattleQueue.Count != 0)
            {
                bool animComplete = false;
                bool isAttacker = _BattleQueue.Dequeue()._IsAttacker;
                if (isAttacker)
                {
                    Debug.Log($"{_Attacker.name}攻击了{_Attacked.name}");
                    _AttackerAnim.Play(EAnimState.Attack, false, () =>
                                                                 {
                                                                     _AttackerAnim.Play(EAnimState.Idle);
                                                                     animComplete = true;
                                                                 });
                }
                else
                {
                    Debug.Log($"{_Attacked.name}攻击了{_Attacker.name}");
                    _AttackedAnim.Play(EAnimState.Attack, false, () =>
                                                                 {
                                                                     _AttackedAnim.Play(EAnimState.Idle);
                                                                     animComplete = true;
                                                                 });
                }

                while (!animComplete)
                {
                    await UniTask.DelayFrame(1);
                }
            }

            EndBattle();
        }

        private void EndBattle()
        {
            Destroy(_AttackerAnim._GO);
            Destroy(_AttackedAnim._GO);

            _AttackerAnim = null;
            _AttackedAnim = null;
        }
    }
}