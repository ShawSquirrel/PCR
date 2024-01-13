using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public Transform start;
    public Transform goal;

    public LayerMask obstacleLayer;

    private Node[,] _grid;
    private List<Node> _openSet;
    private List<Node> _closedSet;


    public int gridSizeX;
    public int gridSizeY;

    private void Start()
    {
        // 初始化网格
        InitializeGrid();

        // 执行A*算法
        FindPath();
    }

    private void InitializeGrid()
    {
        // 根据你的场景设置网格的大小和每个格子的大小

        // 计算网格大小和每个格子的大小

        // 创建网格
        _grid = new Node[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPosition = new Vector3(x, y, 0);
                bool walkable = !Physics2D.OverlapCircle(worldPosition, 0.1f, obstacleLayer);
                _grid[x, y] = new Node(walkable, worldPosition, x, y);
            }
        }
    }

    private void FindPath()
    {
        _grid = new Node[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                _grid[x, y].Reset();
            }
        }

        _openSet = new List<Node>();
        _closedSet = new List<Node>();

        Node startNode = NodeFromWorldPoint(start.position);
        Node goalNode = NodeFromWorldPoint(goal.position);

        _openSet.Add(startNode);

        while (_openSet.Count > 0)
        {
            Node currentNode = _openSet[0];
            for (int i = 1; i < _openSet.Count; i++)
            {
                if (_openSet[i].FCost < currentNode.FCost || (_openSet[i].FCost == currentNode.FCost && _openSet[i].HCost < currentNode.HCost))
                {
                    currentNode = _openSet[i];
                }
            }

            _openSet.Remove(currentNode);
            _closedSet.Add(currentNode);

            if (currentNode == goalNode)
            {
                // 找到路径
                RetracePath(startNode, goalNode);
                return;
            }

            foreach (Node neighbor in GetNeighbors(currentNode))
            {
                if (!neighbor.Walkable || _closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbor = currentNode.GCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.GCost || !_openSet.Contains(neighbor))
                {
                    neighbor.GCost = newCostToNeighbor;
                    neighbor.HCost = GetDistance(neighbor, goalNode);
                    neighbor.Parent = currentNode;

                    if (!_openSet.Contains(neighbor))
                    {
                        _openSet.Add(neighbor);
                    }
                }
            }
        }

        // 没有找到路径
        Debug.Log("No path found");
    }

    private void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Reverse();

        // 在这里你可以处理路径，比如移动角色等
        Debug.Log("Path found!");
    }

    private List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.GridX + x;
                int checkY = node.GridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbors.Add(_grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }

    private int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.GridX - nodeB.GridX);
        int dstY = Mathf.Abs(nodeA.GridY - nodeB.GridY);

        return dstX + dstY;
    }

    private Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x);
        int y = Mathf.RoundToInt(worldPosition.y);
        return _grid[x, y];
    }

    // Node类表示网格中的一个节点
    public class Node
    {
        public bool Walkable;
        public Vector3 WorldPosition;
        public int GridX;
        public int GridY;

        public int GCost; // 从起始点到此点的实际代价
        public int HCost; // 从此点到目标点的估算代价
        public int CurCost;
        public Node Parent; // 在路径中的上一个节点

        public Node(bool walkable, Vector3 worldPosition, int gridX, int gridY)
        {
            Walkable = walkable;
            WorldPosition = worldPosition;
            GridX = gridX;
            GridY = gridY;
        }

        public void Reset()
        {
            GCost = 0;
            HCost = 0;
            Parent = null;
        }

        public int FCost => GCost + HCost + CurCost;
    }
}