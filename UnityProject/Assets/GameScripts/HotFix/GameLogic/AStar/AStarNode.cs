using UnityEngine;

namespace GameLogic
{
    // Node类表示网格中的一个节点
    public class AStarNode
    {
        public bool Walkable;
        public int GridX;
        public int GridY;

        public int GCost;        // 从起始点到此点的实际代价
        public int HCost;        // 从此点到目标点的估算代价
        public int CurCost;      // 这个瓦块的消费
        public AStarNode Parent; // 在路径中的上一个节点

        public Vector2Int Pos => new Vector2Int(GridX, GridY);

        public void Reset()
        {
            GCost  = 0;
            HCost  = 0;
            Parent = null;
        }

        public int FCost => GCost + HCost;
    }
}