using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public static int gridWidth;
    public static int gridHeight;
    [NonSerialized] public static GameObject[,] gridSpaces;

    private Grid _grid;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;

    private void Start()
    {
        _grid = new Grid(width, height);
        gridWidth = _grid.GetWidth(_grid);
        gridHeight = _grid.GetHeight(_grid);

        gridSpaces = new GameObject[gridWidth, gridHeight];

        SetupTiles();
    }

    private void SetupTiles()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                gridSpaces[x, y] = tileGo;
            }
        }
    }
}
