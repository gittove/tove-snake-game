using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float moveTimer;
    private float moveQueue;
    private float _repeatRate = 5f;
    private Vector3 _currentPosition;
    private Vector3Int _currentDirection;
    private Vector3Int[] _directions = new Vector3Int[4] {Vector3Int.up, Vector3Int.down, Vector3Int.right, Vector3Int.left};

    void Start()
    {
        moveTimer = 0f;
        moveQueue = 1f;

        ChangeDirection(2);
    }

    private void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveQueue)
        {
            MoveSnake();
            moveQueue += 1f;
        }

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

    private void MoveSnake()
    {
        transform.position += _currentDirection;

        if (LevelGenerator.gridSpaces[(int)_currentPosition.x, (int)_currentPosition.y] == null)
        {
            // do ded
        }

        //todo snakeNode movement-method call
    }

    private void Inputs()
    {
        
    }

    private void ChangeDirection(int i)
    {
        _currentDirection = new Vector3Int(0, 0, 0);
        _currentDirection = _directions[i];
    }
}
