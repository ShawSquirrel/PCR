using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameLogic
{
    public class AStarManager : MonoBehaviour
    {
        private AStarNode[,] _grid;

        private int _gridSizeX;
        private int _gridSizeY;

        private void Awake()
        {
            LevelManager.Instance._AStarManager = this;
        }

        public void Init(MapData mapList)
        {
            _gridSizeX = mapList._Width;
            _gridSizeY = mapList._Length;

            _grid = new AStarNode[_gridSizeX, _gridSizeY];
            for (int x = 0; x < _gridSizeX; x++)
            {
                for (int y = 0; y < _gridSizeY; y++)
                {
                    bool walkable = mapList._MapList[x, y] != 0;
                    _grid[x, y] = new AStarNode
                                  {
                                      Walkable = walkable,
                                      GridX    = x,
                                      GridY    = y,
                                      CurCost  = mapList._MapList[x, y],
                                  };
                }
            }
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
        
        public List<AStarNode> FindPath(Vector2Int start, Vector2Int end)
        {
            for (int x = 0; x < _gridSizeX; x++)
            {
                for (int y = 0; y < _gridSizeY; y++)
                {
                    _grid[x, y].Reset();
                }
            }

            List<AStarNode> openSet = new List<AStarNode>();
            List<AStarNode> closedSet = new List<AStarNode>();

            AStarNode startNode = _grid[start.x, start.y];
            AStarNode goalNode = _grid[end.x, end.y];
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                AStarNode currentNode = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].FCost < currentNode.FCost || (openSet[i].FCost == currentNode.FCost && openSet[i].HCost < currentNode.HCost))
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == goalNode)
                {
                    // 找到路径
                    return RetracePath(startNode, goalNode);
                }

                foreach (AStarNode neighbor in GetNeighbors(currentNode))
                {
                    if (!neighbor.Walkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int newCostToNeighbor = currentNode.GCost + GetDistance(currentNode, neighbor) + currentNode.CurCost;
                    if (newCostToNeighbor < neighbor.GCost || !openSet.Contains(neighbor))
                    {
                        neighbor.GCost  = newCostToNeighbor;
                        neighbor.HCost  = GetDistance(neighbor, goalNode);
                        neighbor.Parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            // 没有找到路径
            Debug.Log("No path found");
            return null;
        }

        private List<AStarNode> RetracePath(AStarNode startNode, AStarNode endNode)
        {
            List<AStarNode> path = new List<AStarNode>();
            AStarNode currentNode = endNode;

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

        private List<AStarNode> GetNeighbors(AStarNode node)
        {
            List<AStarNode> neighbors = new List<AStarNode>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x != 0 && y != 0) continue;
                    int checkX = node.GridX + x;
                    int checkY = node.GridY + y;

                    if (checkX >= 0 && checkX < _gridSizeX && checkY >= 0 && checkY < _gridSizeY)
                    {
                        neighbors.Add(_grid[checkX, checkY]);
                    }
                }
            }

            return neighbors;
        }

        private int GetDistance(AStarNode nodeA, AStarNode nodeB)
        {
            int dstX = Mathf.Abs(nodeA.GridX - nodeB.GridX);
            int dstY = Mathf.Abs(nodeA.GridY - nodeB.GridY);

            return dstX + dstY;
        }
    }
    
}