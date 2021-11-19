using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int gCost;
    public int hCost;
    public int gridX;
    public int gridY;
    public bool walkable;
    public Vector3 position;
    public Tile parent;

    public Tile(bool _walkable, Vector3 _position, int _gridX, int _gridY)
    {
        position = _position;
        gridX = _gridX;
        gridY = _gridY;
        walkable = _walkable;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
    
}
