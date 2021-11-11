using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float moveQueue;
    private float moveTimer;
    private float _repeatRate = 5f;
    private Vector3 _currentPosition;
    private Vector3Int _currentDirection;
    private Vector3Int[] _directions = new Vector3Int[4] {Vector3Int.up, Vector3Int.down, Vector3Int.right, Vector3Int.left};
    private GameObject[,] _gridSpaces;

    void Start()
    {
        moveTimer = 0f;
      // _gridSpaces = LevelGenerator.gridSpaces;

        ChangeDirection(2);
    }

    private void Update()
    {
        Inputs();

        moveTimer += Time.deltaTime;

        if (moveTimer >= moveQueue)
        {
            MoveSnake();
            moveTimer = 0f;
        }
    }

    private void MoveSnake()
    {
        transform.position += _currentDirection;

        if (LevelGenerator.gridSpaces[(int)_currentPosition.x, (int)_currentPosition.y] == null)
        {
            // do ded
        }
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
