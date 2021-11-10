using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;

    private int width;
    private int height;
    private Grid _grid;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;

    private void Start()
    {
        StartCoroutine(Generate());
        width = _grid.GetWidth(_grid);
        height = _grid.GetHeight(_grid);
        Level.instance.gridSpaces = new GameObject[width,height];
        SetupTiles();
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        _grid = new Grid(gridWidth, gridHeight);

        yield return wait;
    }

    private void SetupTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x, y, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                Level.instance.gridSpaces[x, y] = tileGo;
            }
        }
    }
}
