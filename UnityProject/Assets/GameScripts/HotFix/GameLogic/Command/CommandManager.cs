using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class CommandManager : MonoBehaviour
    {
        public Dictionary<int, Stack<ICommand>> _CommandDict = new Dictionary<int, Stack<ICommand>>();
        public int RoundCount => LevelManager.Instance._RoundCount;
        
        private void Awake()
        {
            LevelManager.Instance._CommandManager = this;
            _CommandDict[0]                       = new Stack<ICommand>();
        }

        public void AddRound()
        {
            _CommandDict[RoundCount] = new Stack<ICommand>();
        }


        public void Execute(ICommand command)
        {
            command.Do();
            _CommandDict[RoundCount].Push(command);
        }

        public void FallBack()
        {
            if (_CommandDict[RoundCount].TryPop(out ICommand command))
            {
                command.UnDo();
            }
        }
    }
}