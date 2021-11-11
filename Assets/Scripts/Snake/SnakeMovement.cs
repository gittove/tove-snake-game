using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float moveQueue;
    private float moveTimer;
    private float _repeatRate = 5f;
    private Vector3 startPosition = new Vector3(0.5f, 0.5f);
    private Vector3 _currentPosition;
    private Vector3Int _currentDirection;
    private Vector3Int _currentRotation;
    private Vector3Int[] _directions = new Vector3Int[4] {Vector3Int.up, Vector3Int.down, Vector3Int.right, Vector3Int.left};
    private Vector3Int[] _rotations = new Vector3Int[4] { new Vector3Int(0, 0, 90), new Vector3Int(0, 0, -90), new Vector3Int(0, 0, 0), new Vector3Int(0, 0, 180) };
    private SnakeBody snakeBody;
    private GameObject[,] _gridSpaces;

    void Start()
    {
        transform.position = startPosition;
        snakeBody = GetComponent<SnakeBody>();
        moveTimer = 0f;

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
        snakeBody._snakeBody.MoveNodes(transform);
        transform.position += _currentDirection;

        if (LevelGenerator.gridSpaces[(int)_currentPosition.x, (int)_currentPosition.y] == null)
        {
            // do ded
        }
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeDirection(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeDirection(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeDirection(2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeDirection(3);
        }
    }

    private void ChangeDirection(int i)
    {
        _currentDirection = new Vector3Int(0, 0, 0);
        _currentRotation = new Vector3Int(0, 0, 0);
        _currentDirection = _directions[i];
        _currentRotation = _rotations[i];

        transform.rotation = Quaternion.Euler(_currentRotation);
    }
}
