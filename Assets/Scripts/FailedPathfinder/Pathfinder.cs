using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    /*
    [SerializeField] private GameObject _levelManager;
    private LevelGenerator _levelGenerator;
    private SnakeBody _snakeBody;
    private Tile gizmosTile;

    private void Awake()
    {
        _levelGenerator = _levelManager.GetComponent<LevelGenerator>();
        _snakeBody = GetComponent<SnakeBody>();
    }

    public List<Tile> FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Tile[,] tempClone = LevelGenerator.PFgridSpaces;
        Tile[,] _grid = tempClone;
        Tile startTile = _grid[Mathf.RoundToInt(startPos.x), Mathf.RoundToInt(startPos.y)];
        Tile targetTile = _grid[Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y)];
        List<Tile> finalPath = new List<Tile>();
        List<Tile> openSet = new List<Tile>();
        HashSet<Tile> closedSet = new HashSet<Tile>();
        HashSet<Vector3> bodyTiles = _snakeBody.snakeList.GetBodyPositions;
        _grid = UpdateWalkables(_grid, bodyTiles);
        openSet.Add(startTile);

        while(openSet.Count > 0)
        {
            Tile currentTile = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentTile.fCost || openSet[i].fCost == currentTile.fCost && openSet[i].hCost < currentTile.hCost)
                {
                    currentTile = openSet[i];
                }
            }

            openSet.Remove(currentTile);
            closedSet.Add(currentTile);

                if (currentTile.position == targetTile.position)
                {
                    finalPath = RetracePath(startTile, targetTile);
                    return finalPath;
                }

                foreach(Tile neighbourTile in _levelGenerator.GetNeighbours(currentTile))
                {
                    if (!neighbourTile.walkable || closedSet.Contains(neighbourTile))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentTile.gCost + GetDistance(currentTile, neighbourTile);
                    
                    if (newMovementCostToNeighbour <= neighbourTile.gCost || !openSet.Contains(neighbourTile))
                    {
                        neighbourTile.gCost = newMovementCostToNeighbour;
                        neighbourTile.hCost = GetDistance(neighbourTile, targetTile);
                        neighbourTile.parent = currentTile;

                        if (!openSet.Contains(neighbourTile))
                        {
                            openSet.Add(neighbourTile);
                        }
                    }
                }
        }
        finalPath = RetracePath(startTile, targetTile);
        return finalPath;
    }

    private List<Tile> RetracePath(Tile startTile, Tile targetTile)
    {
        List<Tile> path = new List<Tile>();
        Tile currentTile = targetTile;

        while (currentTile != startTile)
        {
            path.Add(currentTile);
            currentTile = currentTile.parent;
        }
        path.Reverse();

        return path;
    }

    private int GetDistance(Tile tileA, Tile tileB)
    {
        int distX = Mathf.Abs(tileA.gridX - tileB.gridX);
        int distY = Mathf.Abs(tileA.gridY - tileB.gridY);

        if (distX > distY)
        {
            return 10*distY + 10 * (distX - distY);
        }
        return 10*distX + 10 * (distY - distX);
    }

    private Tile[,] UpdateWalkables(Tile [,] grid, HashSet<Vector3> bodyPositions)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (bodyPositions.Contains(grid[x, y].position))
                {
                    grid[x, y].walkable = false;
                }
            }
        }
        return grid;
    } */
}
