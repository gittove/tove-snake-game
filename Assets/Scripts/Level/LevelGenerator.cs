using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static Vector2 gridSize;
    [NonSerialized] public static Tile[,] PFgridSpaces;
    [NonSerialized] public static GameObject[,] MAgridSpaces;

    //if in awake; bool = true/false => enable relevant script
    [SerializeField] private bool _pathfinder;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;
    private Vector2Int[] neighbourDirections;

    private void Awake()
    {
        PFgridSpaces = GetComponent<GridSizeToCamera>().SetGridSize();
        gridSize = new Vector2(PFgridSpaces.GetLength(0), PFgridSpaces.GetLength(1));
        neighbourDirections = new Vector2Int[4] { new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(0, 1), new Vector2Int(1, 0) };

      //  if (_pathfinder)
       // {
            SetupPathfindingTiles();
       // }
       // else
       // {
       //     SetupTiles();
       // }
    }

    private void SetupPathfindingTiles()
    {
        for (int x = 0; x < (int)gridSize.x; x++)
        {
            for (int y = 0; y < (int)gridSize.y; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                PFgridSpaces[x, y] = new Tile(true, tileGo.transform.position, x, y);
            }
        }
    }

    private void SetupTiles()
    {
        for (int x = 0; x < (int)gridSize.x; x++)
        {
            for (int y = 0; y < (int)gridSize.y; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                MAgridSpaces[x, y] = tileGo;
            }
        }
    }

    public List<Tile> GetNeighbours(Tile tile)
    {
        List<Tile> neighbours = new List<Tile>();
        int x = 0;
        int y = 0;

        for (int i = 0; i < neighbourDirections.Length; i++)
        {
            x = tile.gridX + neighbourDirections[i].x;
            y = tile.gridY + neighbourDirections[i].y;
            
            x = Wrap(x, 0, Mathf.RoundToInt(gridSize.x));
            y = Wrap(y, 0, Mathf.RoundToInt(gridSize.y));

            neighbours.Add(PFgridSpaces[x, y]);
        }

        return neighbours;
    }

    private int Wrap(int pos, int minValue, int maxValue)
    {
        int distance = maxValue - minValue;
        int rest = ((pos + distance) % distance) + minValue;
        return rest;
    }
}
