using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static int gridWidth;
    [NonSerialized] public static int gridHeight;
   // [NonSerialized] public static int gridDepth;
    [NonSerialized] public static GameObject[,] gridSpaces;

    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesTransform;
    [NonSerialized, Range(0f, 1f)] private float offset = 0.5f;

    private void Awake()
    {
        gridSpaces = GetComponent<GridSizeToCamera>().SetGridSize();

        gridWidth = gridSpaces.GetLength(0);
        gridHeight = gridSpaces.GetLength(1);
        SetupTiles();
    }

    private void SetupTiles()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject tileGo = Instantiate(_tilePrefab, new Vector3(x - offset, y - offset, 0f), Quaternion.identity, _tilesTransform);
                tileGo.name = $"Tile_({x}, {y})";
                gridSpaces[x, y] = tileGo;
            }
        }
    }
}
