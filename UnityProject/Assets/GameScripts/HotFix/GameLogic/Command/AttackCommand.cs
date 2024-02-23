using UnityEngine;

namespace GameLogic
{
    public class AttackCommand : ICommand
    {
        public Character_Old _Attacker;
        public Character_Old _Attacked;
        
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