using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private float _gridWidth;
    private float _gridHeight;

    private void Start()
    {
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        _gridWidth = LevelGenerator.gridWidth;
        _gridHeight = LevelGenerator.gridHeight;

        int randomX = Random.Range(0, (int)_gridWidth);
        int randomY = Random.Range(0, (int)_gridHeight);

        transform.position = new Vector3(randomX - 0.5f, randomY - 0.5f, 0);
    }
}
