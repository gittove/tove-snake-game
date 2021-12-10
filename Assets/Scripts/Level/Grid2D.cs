using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D
{
    public int sizeOfTile;
    public Vector2Int sizeOfGrid;
    public Vector2[,] grid;
    public Vector2 startingPos;
    public Transform boardParent;
    public GameObject prefab;

    private Vector2Int _currentPosOnGrid;

    public Grid2D (Vector2Int tempSizeOfGrid, Vector2 tempStartingPos, int tempSizeOfTile, GameObject tempTilePrefab, Transform tempBoardParent)
    {
        sizeOfTile = tempSizeOfTile;
        sizeOfGrid = tempSizeOfGrid;
        startingPos = tempStartingPos;
        prefab = tempTilePrefab;
        boardParent = tempBoardParent;
        _currentPosOnGrid = new Vector2Int(0, 0);

        grid = new Vector2[sizeOfGrid.y, sizeOfGrid.x];
    }

    public Vector2 GetWorldPos(Vector2Int addDirection)
    {
        _currentPosOnGrid.x += addDirection.x;
        _currentPosOnGrid.y += addDirection.y;
        
        _currentPosOnGrid.x = WrapPosition(_currentPosOnGrid.x, 0, grid.GetLength(1));
        _currentPosOnGrid.y = WrapPosition(_currentPosOnGrid.y, 0, grid.GetLength(0));
        
        return grid[_currentPosOnGrid.y, _currentPosOnGrid.x];
    }
    
    private int WrapPosition(int currentValue, int addValue, int max)
    {
        return Mathf.RoundToInt(((currentValue + addValue) % max+max) % max);
    }
}
