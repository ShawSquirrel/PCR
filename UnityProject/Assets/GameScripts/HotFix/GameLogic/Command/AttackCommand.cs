using UnityEngine;

namespace GameLogic
{
    public class AttackCommand : ICommand
    {
        public Character _Attacker;
        public Character _Attacked;
        
        public void Do()
        {
            LevelManager.Instance._BattleManager.InitBattle(_Attacker, _Attacked);
            LevelManager.Instance._BattleManager.PlayBattle();
        }

        public void UnDo()
        {
        }
    }
}