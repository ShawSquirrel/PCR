using UnityEngine;

namespace GameLogic
{
    public class MoveCommand : ICommand
    {
        public IMove _Move;
        public Vector2Int _StartPos;
        public Vector2Int _EndPos;
        public void Do()
        {
            _Move.Move(_StartPos, _EndPos);
        }

        public void UnDo()
        {
            _Move.Move(_EndPos, _StartPos);
        }
    }
}