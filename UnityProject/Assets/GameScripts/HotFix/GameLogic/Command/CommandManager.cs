using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class CommandManager : MonoBehaviour
    {
        private readonly Dictionary<int, Stack<ICommand>> _CommandDict = new Dictionary<int, Stack<ICommand>>();
        private static int RoundCount => LevelManager.Instance._RoundManager._RoundCount;

        private void Awake()
        {
            LevelManager.Instance._CommandManager = this;
            transform.SetParent(LevelManager.Instance._Root);
            _CommandDict[0] = new Stack<ICommand>();
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