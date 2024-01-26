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
        private Character _attacker;
        private Character _attacked;

        public Transform _AttackerPos;
        public Transform _AttackedPos;

        private AnimComponent _attackerAnim;
        private AnimComponent _attackedAnim;

        private Queue<BattleItem> _battleQueue = new Queue<BattleItem>();

        protected override void Awake()
        {
            base.Awake();
            LevelManager.Instance._BattleManager = this;
            _TF.SetParent(LevelManager.Instance._Root);
        }


        public void InitBattle(Character attacker, Character attacked)
        {
            _attacker = attacker;
            _attacked = attacked;

            _attackerAnim                   = GameModule.Resource.LoadAsset<GameObject>("优衣Body").GetComponent<AnimComponent>();
            _attackerAnim._TF.localScale    = new Vector3(0.5f, 0.5f, 0.5f);
            _attackerAnim._TF.SetParent(_AttackerPos);
            _attackerAnim._TF.localPosition = Vector3.zero;

            _attackedAnim                = GameModule.Resource.LoadAsset<GameObject>("镜华Body").GetComponent<AnimComponent>();
            _attackedAnim._TF.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            _attackedAnim._TF.SetParent(_AttackedPos);
            _attackedAnim._TF.localPosition   = Vector3.zero;

            int speedAttacker = _attacker._Attribute.Constant._SpeedValue;
            int speedAttacked = _attacked._Attribute.Constant._SpeedValue;


            _battleQueue.Clear();
            switch (speedAttacker - speedAttacked)
            {
                case < 0:
                {
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                }
                    break;
                case > 0:
                {
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                }
                    break;
                default:
                {
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = true });
                    _battleQueue.Enqueue(new BattleItem() { _IsAttacker = false });
                }
                    break;
            }
        }

        public async void PlayBattle()
        {
            while (_battleQueue.Count != 0)
            {
                bool animComplete = false;
                bool isAttacker = _battleQueue.Dequeue()._IsAttacker;
                if (isAttacker)
                {
                    Debug.Log($"{_attacker.name}攻击了{_attacked.name}");
                    _attackerAnim.Play(EAnimState.Attack, false, () =>
                                                                 {
                                                                     _attackerAnim.Play(EAnimState.Idle);
                                                                     animComplete = true;
                                                                 });
                }
                else
                {
                    Debug.Log($"{_attacked.name}攻击了{_attacker.name}");
                    _attackedAnim.Play(EAnimState.Attack, false, () =>
                                                                 {
                                                                     _attackedAnim.Play(EAnimState.Idle);
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
            Destroy(_attackerAnim._GO);
            Destroy(_attackedAnim._GO);

            _attackerAnim = null;
            _attackedAnim = null;
        }
    }
}