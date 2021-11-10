using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public int width;
    public int height;
    [NonSerialized] public static GameObject[,] gridSpaces;

    private int _gridWidth;
    private int _gridHeight;
    private Grid _grid;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;

    private void Start()
    {
        _grid = new Grid(width, height);
        _gridWidth = _grid.GetWidth(_grid);
        _gridHeight = _grid.GetHeight(_grid);

        gridSpaces = new GameObject[_gridWidth, _gridHeight];

        SetupTiles();
    }

    private void SetupTiles()
    {
        for (int x = 0; x < _gridWidth; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                gridSpaces[x, y] = tileGo;
            }
        }
    }
}
