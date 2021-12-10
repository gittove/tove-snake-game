using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [NonSerialized] public static Vector2Int gridSize;
    [NonSerialized] public static Grid2D grid2D;

    [NonSerialized] private int _tileSize;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _boardParent;

    private void Awake()
    {
        gridSize = GetComponent<GridSizeToCamera>().SetGridSize();
        _tileSize = 1;
        grid2D = new Grid2D(gridSize, transform.position, _tileSize, _tilePrefab, _boardParent);
    }

    private void Start()
    {
        SetUpGrid();
    }

    private void SetUpGrid()
    {
        float tilePosX = grid2D.startingPos.x;
        float tilePosY = grid2D.startingPos.y;
        
        for (int i = 0; i < grid2D.grid.GetLength(1); i++)
        {
            for (int k = 0; k < grid2D.grid.GetLength(0); k++)
            {
                GameObject tileGo = Instantiate(grid2D.prefab, new Vector3(tilePosX, tilePosY, 0f), Quaternion.identity, grid2D.boardParent);
                tileGo.name = $"Tile_({tilePosX}, {tilePosY})";
                grid2D.grid[k, i] = tileGo.transform.position;

                tilePosY += grid2D.sizeOfTile;
            }

            tilePosY = 0;
            tilePosX += grid2D.sizeOfTile;
        }
    } 
}
