using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameBase;
using UnityEngine;

namespace GameLogic
{
    public class Character : MonoBehaviour, IMove
    {
        private Vector2Int _pos;

        public Vector2Int _CurPos

        {
            get => _pos;
            set
            {
                _pos               = value;
                transform.position = new Vector3(_pos.x, _pos.y);
            }
        }
        
        public async void Move(Vector2Int start, Vector2Int end)
        {
            List<AStarNode> path = LevelManager.Instance._AStarManager.FindPath(start, end);
            Debug.Log(path[^1].FCost);
            foreach (AStarNode node in path)
            {
                bool isComplete = false;
                DOTween.To(() => transform.position,
                           (value) => transform.position = value,
                           new Vector3(node.GridX, node.GridY), 1f).SetEase(Ease.Linear).OnComplete(() => isComplete = true);

                while (!isComplete)
                {
                    await UniTask.DelayFrame(1);
                }
            }
        }
    }

    public interface IMove
    {
        public void Move(Vector2Int start, Vector2Int end);
    }
}