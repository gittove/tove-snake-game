using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//do i even need this wtf
public class Grid
{
    private int _width;
    private int _height;
    private Vector3[,] _gridArr;

    public Grid(int width, int height)
    {
        this._width = width;
        this._height = height;

        //this makes no sense, help
        this._gridArr = new Vector3[width,height];
    }

    public int GetWidth(Grid grid)
    {
        return grid._width;
    }

    public int GetHeight(Grid grid)
    {
        return grid._height;
    }

    public Vector3[,] GetVector3s(Grid grid)
    {
        return grid._gridArr;
    }
}
