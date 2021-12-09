using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static Vector2 gridSize;
    [NonSerialized] public static Vector2 [,] gridSpaces;

    [NonSerialized] private int _tileSize;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;

    private void Awake()
    {
        gridSpaces = GetComponent<GridSizeToCamera>().SetGridSize();
        gridSize = new Vector2(gridSpaces.GetLength(0), gridSpaces.GetLength(1));
        _tileSize = 1;
    }

    private void Start()
    {
        SetUpGrid();
    }

    private void SetUpGrid()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        
        for (int i = 0; i < (int)gridSize.x; i++)
        {
            for (int k = 0; k < (int)gridSize.y; k++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                gridSpaces[i, k] = tileGo.transform.position;

                x += _tileSize;
                y += _tileSize;
            }
        }
    }
}
