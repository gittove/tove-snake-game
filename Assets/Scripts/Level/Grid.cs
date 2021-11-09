using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//do i even need this wtf
public class Grid
{
    private int _width;
    private int _height;
    private Vector2[,] _grid;

    public Grid(int width, int height)
    {
        this._width = width;
        this._height = height;

        this._grid = new Vector2[width,height];
        /*
        for (int y = 0; y < this.height; y++)
        {
            for (int x = 0; x < this.width; x++)
            {
                grid[x, y] = new Vector2(x, y);
            }
        } */
    }

    public int GetWidth(Grid grid)
    {
        return grid._width;
    }

    public int GetHeight(Grid grid)
    {
        return grid._height;
    }
}
