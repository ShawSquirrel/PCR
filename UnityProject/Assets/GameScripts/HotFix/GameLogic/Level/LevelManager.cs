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
        public MapManager _MapManager;
        public AStarManager _AStarManager;
        public CharacterManager _CharacterManager;
        public CommandManager _CommandManager;

        public int _RoundCount;

        public void Init()
        {
            AddRound();
        }

        public void ClickMapItem(Vector2Int end)
        {
            MoveCommand moveCommand = new MoveCommand
                                      {
                                          _Move     = _CharacterManager._FriendlyCharacter[0],
                                          _StartPos = _CharacterManager._FriendlyCharacter[0]._CurPos,
                                          _EndPos   = end
                                      };
            _CommandManager.Execute(moveCommand);
        }

        public void AddRound()
        {
            _RoundCount++;
            _CommandManager.AddRound();
        }
        
    }
}