using System.Collections.Generic;
using GameBase;
using UnityEngine;

public class AStar : Singleton<AStar>
{
    private Node[,] _grid;
    private List<Node> _openSet;
    private List<Node> _closedSet;


    public int gridSizeX;
    public int gridSizeY;

    public void Init(List<List<int>> mapList)
    {
        // 初始化网格
        InitializeGrid(mapList);

        // 执行A*算法
        // FindPath();
    }

    public int[,] GetAllCost(Vector2Int start)
    {
        int[,] result = new int[6, 6];
        for (int i = 0; i < 6; i++)
        {
            for (int ii = 0; ii < 6; ii++)
            {
                var pathList = FindPath(start, _grid[i, ii].Pos);
                if (pathList == null || pathList.Count == 0)
                {
                    result[i, ii] = 0;
                }
                else
                {
                    result[i, ii] = pathList[^1].FCost;
                }
            } 
        }

        return result;
    }

    private void InitializeGrid(List<List<int>> mapList)
    {
        // 根据你的场景设置网格的大小和每个格子的大小

        // 计算网格大小和每个格子的大小
        gridSizeX = mapList.Count;
        gridSizeY = mapList[0].Count;
        // 创建网格
        _grid = new Node[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                bool walkable = mapList[x][y] != 0;
                _grid[x, y] = new Node
                              {
                                  Walkable = walkable,
                                  GridX    = x,
                                  GridY    = y,
                                  CurCost  = mapList[y][x],
                              };
            }
        }
    }

    public List<Node> FindPath(Vector2Int start, Vector2Int end)
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                _grid[x, y].Reset();
            }
        }

        _openSet   = new List<Node>();
        _closedSet = new List<Node>();

        Node startNode = _grid[start.x, start.y];
        Node goalNode = _grid[end.x, end.y];
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
                return RetracePath(startNode, goalNode);
            }

            foreach (Node neighbor in GetNeighbors(currentNode))
            {
                if (!neighbor.Walkable || _closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbor = currentNode.GCost + GetDistance(currentNode, neighbor) + currentNode.CurCost;
                if (newCostToNeighbor < neighbor.GCost || !_openSet.Contains(neighbor))
                {
                    neighbor.GCost  = newCostToNeighbor;
                    neighbor.HCost  = GetDistance(neighbor, goalNode);
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
        return null;
    }

    private List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        // Debug.Log("Path found!");
        return path;
        // 在这里你可以处理路径，比如移动角色等
    }

    private List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x != 0 && y != 0) continue;
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

    // Node类表示网格中的一个节点
    public class Node
    {
        public bool Walkable;
        public int GridX;
        public int GridY;

        public int GCost;   // 从起始点到此点的实际代价
        public int HCost;   // 从此点到目标点的估算代价
        public int CurCost; // 这个瓦块的消费
        public Node Parent; // 在路径中的上一个节点

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