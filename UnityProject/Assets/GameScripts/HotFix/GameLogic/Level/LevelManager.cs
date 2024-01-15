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

        public Transform _Player;

        public void Init()
        {
            GameEvent.AddEventListener<Vector2Int>(EventID.ClickMapItemID, OnClickMapItem);
        }

        private async void OnClickMapItem(Vector2Int v2)
        {
            List<AStarNode> path = _AStarManager.FindPath(_Player.position.ToVector2Int(), v2);
            Debug.Log(path[^1].FCost);
            foreach (AStarNode node in path)
            {
                bool isComplete = false;
                DOTween.To(() => _Player.position,
                           (value) => _Player.position = value,
                           new Vector3(node.GridX, node.GridY), 1f).OnComplete(() => isComplete = true);

                while (!isComplete)
                {
                    await UniTask.DelayFrame(1);
                }
            }
        }
    }
}