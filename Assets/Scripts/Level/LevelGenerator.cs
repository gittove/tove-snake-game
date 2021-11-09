using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;

   // private Vector2[,] grid;
    private Grid _grid;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        _grid = new Grid(gridWidth, gridHeight);

        yield return wait;
    }

    private void OnDrawGizmos()
    {
        if (_grid == null) return;

        Gizmos.color = Color.black;
        for (int i = 0; i < _grid.GetHeight(_grid); i++)
        {
            for (int k = 0; k < _grid.GetWidth(_grid); k++)
            {
                Gizmos.DrawCube(new Vector3(i, k, 0), new Vector3(0.05f, 0.05f, 0));
            }
        }
    }
}
