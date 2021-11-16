using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private int _gridWidth;
    private int _gridHeight;
    private float _nextPositionX;
    private float _nextPositionY;
    private float _moveQueue;
    private float _moveTimer;
    private Vector3Int _currentDirection;
    private Vector3Int _currentRotation;
    private Vector3 _nextPosition;
    private SnakeBody _snakeBody;
    private GameState _gameState;

    private Vector3[,] directions;
    private Vector3Int[] _directions = new Vector3Int[4] { Vector3Int.up, Vector3Int.down, Vector3Int.right, Vector3Int.left };
    private Vector3Int[] _rotations = new Vector3Int[4] { new Vector3Int(0, 0, 90), new Vector3Int(0, 0, -90), new Vector3Int(0, 0, 0), new Vector3Int(0, 0, 180) };

    void Start()
    {
        _gridWidth = LevelGenerator.gridWidth;
        _gridHeight = LevelGenerator.gridHeight;
        _snakeBody = GetComponent<SnakeBody>();
        _moveQueue = 0.5f;
        _moveTimer = 0f;
        _gameState = GetComponent<GameState>();

        ChangeDirection(2);
    }

    private void Update()
    {
        Inputs();

        _moveTimer += Time.deltaTime;

        if (_moveTimer >= _moveQueue)
        {
            MoveSnake();
            _moveTimer = 0f;
        }
    }

    private void MoveSnake()
    {
        _nextPositionX = WrapPosition(transform.position.x, _currentDirection.x, _gridWidth);
        _nextPositionY = WrapPosition(transform.position.y, _currentDirection.y, _gridHeight);
        _nextPosition = new Vector3(_nextPositionX, _nextPositionY, 0f);

        _gameState.CheckForGameOver(_nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, new Vector3(_nextPositionX, _nextPositionY, 0f));
        transform.position = new Vector3(_nextPositionX, _nextPositionY, 0f);
    }
    

    private float WrapPosition(float currentValue, int addValue, int max)
    {
        return ((currentValue + addValue) % max+max) % max;
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
        _currentDirection = _directions[i];
        _currentRotation = _rotations[i];

        transform.rotation = Quaternion.Euler(_currentRotation);
    }
}
