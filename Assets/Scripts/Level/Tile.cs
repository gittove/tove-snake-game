using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Vector3 position;
    public int gCost;
    public int hCost;
    public int gridX;
    public int gridY;
    public Tile parent;

    public Tile(Vector3 pos, int _gridX, int _gridY)
    {
        position = pos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
    
}
