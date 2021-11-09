using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float _repeatRate = 5f;
    private Vector3Int _currentDirection;
    private Vector3Int[] _directions = new Vector3Int[4] {Vector3Int.up, Vector3Int.down, Vector3Int.right, Vector3Int.left};

    void Start()
    {
        ChangeDirection(0);
        InvokeRepeating("MoveSnake", 0, _repeatRate);
    }

    private void MoveSnake()
    {
        this.transform.position += _currentDirection;
        //todo snakeNode movement-method call
    }

    private void Inputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ChangeDirection(0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ChangeDirection(1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ChangeDirection(2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ChangeDirection(3);
        }
    }

    private void ChangeDirection(int i)
    {
        _currentDirection = new Vector3Int(0, 0, 0);
        _currentDirection = _directions[i];
    }
}
