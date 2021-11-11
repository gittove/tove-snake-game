using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static int gridWidth;
    [NonSerialized] public static int gridHeight;
    [NonSerialized] public static GameObject[,] gridSpaces;

    private Vector2 topRightCameraCorner = new Vector2(1, 1);
    private Vector2 edgeVector;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;

    private void Awake()
    {
        edgeVector = Camera.main.ViewportToWorldPoint(topRightCameraCorner);
        gridWidth = (int)edgeVector.x * 2;
        gridHeight = (int)edgeVector.y * 2;

        gridSpaces = new GameObject[gridWidth, gridHeight];
    }

    private void Start()
    {
        SetupTiles();
    }

    private void SetupTiles()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x - 0.5f, y - 0.5f, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                gridSpaces[x, y] = tileGo;
            }
        }
    }
}
