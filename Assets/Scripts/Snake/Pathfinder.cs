using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Tile[,] _grid;
    [SerializeField] private GameObject _levelManager;
    private LevelGenerator _levelGenerator;

    private void Awake()
    {
        _levelGenerator = _levelManager.GetComponent<LevelGenerator>();
    }

    private void Start()
    {
        
    }

    public List<Tile> FindPath(Vector3 startPos, Vector3 targetPos)
    {
        _grid = LevelGenerator.gridSpaces;
        Tile startTile = _grid[Mathf.RoundToInt(startPos.x), Mathf.RoundToInt(startPos.y)];
        Tile targetTile = _grid[Mathf.RoundToInt(targetPos.x), Mathf.RoundToInt(targetPos.y)];
        List<Tile> finalPath = new List<Tile>();
        List<Tile> openSet = new List<Tile>(); // might change to heap later ngl
        HashSet<Tile> closedSet = new HashSet<Tile>();

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

                if (currentTile == targetTile)
                {
                    finalPath = RetracePath(startTile, targetTile);
                    return finalPath;
                }

                foreach(Tile neighbourTile in _levelGenerator.GetNeighbours(currentTile))
                {
                    if (closedSet.Contains(neighbourTile))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentTile.gCost + GetDistance(currentTile, neighbourTile);
                    if (newMovementCostToNeighbour < neighbourTile.gCost || !openSet.Contains(neighbourTile))
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
}
