using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static Vector2 gridSize;
    [NonSerialized] public static Tile[,] gridSpaces;

    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;
   // private float tileRadius;
    private Vector2Int[] neighbourDirections;

    private void Awake()
    {
        gridSpaces = GetComponent<GridSizeToCamera>().SetGridSize();
        gridSize = new Vector2(gridSpaces.GetLength(0), gridSpaces.GetLength(1));
        neighbourDirections = new Vector2Int[4] { new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(0, 1), new Vector2Int(1, 0) };

        SetupTiles();
    }

    private void SetupTiles()
    {
        for (int x = 0; x < (int)gridSize.x; x++)
        {
            for (int y = 0; y < (int)gridSize.y; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                gridSpaces[x, y] = new Tile(tileGo.transform.position, x, y);
            }
        }
    }

    public List<Tile> GetNeighbours(Tile tile)
    {
        List<Tile> neighbours = new List<Tile>();
        int x;
        int y;

        for (int i = 0; i < neighbourDirections.Length; i++)
        {
            x = tile.gridX + neighbourDirections[i].x;
            y = tile.gridY + neighbourDirections[i].y;
            
            x = Wrap(x, 0, Mathf.RoundToInt(gridSize.x));
            y = Wrap(y, 0, Mathf.RoundToInt(gridSize.y));

            neighbours.Add(gridSpaces[x, y]);
        }

        return neighbours;
    }
    /*
    public Vector3 WrapTile(Vector3 nextPos)
    {
        nextPos.x = Wrap(Mathf.RoundToInt(nextPos.x), 0, Mathf.RoundToInt(gridSize.x));
        nextPos.y = Wrap(Mathf.RoundToInt(nextPos.y), 0, Mathf.RoundToInt(gridSize.y));

        return nextPos;
    }
    */
    private int Wrap(int pos, int minValue, int maxValue)
    {
        int distance = maxValue - minValue;
        int rest = ((pos + distance) % distance) + minValue;
        return rest;
    }
}
