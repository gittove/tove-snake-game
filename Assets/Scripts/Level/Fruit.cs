using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private int _gridWidth;
    private int _gridHeight;

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

        int randomX = Random.Range(0, _gridWidth);
        int randomY = Random.Range(0, _gridHeight);

        transform.position = new Vector3(randomX, randomY, 0);
    }
}
