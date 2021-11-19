using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static Vector2 gridSize;
    [NonSerialized] public static GameObject[,] gridSpaces;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;

    private void Awake()
    {
        gridSpaces = GetComponent<GridSizeToCamera>().SetGridSize();
        gridSize = new Vector2(gridSpaces.GetLength(0), gridSpaces.GetLength(1));
    }

    private void Start()
    {
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
                gridSpaces[x, y] = tileGo;
            }
        }
    }
}
