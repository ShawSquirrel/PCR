using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class LevelManager : Singleton<LevelManager>
    {
        public Transform _Root;
        public MapManager _MapManager;
        public AStarManager _AStarManager;
        public CharacterManager _CharacterManager;
        public CommandManager _CommandManager;
        public BattleManager _BattleManager;
        public RoundManager _RoundManager;



        public LevelManager()
        {
            _Root = new GameObject("Level").transform;
        }
        
        public void Init()
        {
            AddRound();
        }

        public void ClickMapItem(Vector2Int end)
        {
            if (_MapManager._MapItemDataDict[end]._Character != null)
            {
                AttackCommand attackCommand = new AttackCommand
                                              {
                                                  _Attacker = _CharacterManager._FriendlyCharacter[0],
                                                  _Attacked = _MapManager._MapItemDataDict[end]._Character
                                              };
                _CommandManager.Execute(attackCommand);
            }
            else
            {
                MoveCommand moveCommand = new MoveCommand
                                          {
                                              _Move     = _CharacterManager._FriendlyCharacter[0],
                                              _StartPos = _CharacterManager._FriendlyCharacter[0]._CurPos,
                                              _EndPos   = end
                                          };
                _CommandManager.Execute(moveCommand);
            }
            
            
        }

        private void AddRound()
        {
            _RoundManager.AddRound();
            _CommandManager.AddRound();
        }

    }
}