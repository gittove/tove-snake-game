using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private float _moveQueue;
    private float _moveTimer;
    private Quaternion _nextRotation;
    private Vector2 _nextPosition;
    private Vector2Int _currentDirection;
    private SnakeMovement _snakeMovement;
    private Dictionary<string, Vector2Int> _directionValues;
    private Dictionary<Vector2Int, Vector3Int> _rotationValues;

    private void Awake()
    {
        _moveQueue = 0.2f;
        _moveTimer = 0f;
        _snakeMovement = GetComponent<SnakeMovement>();
    }

    private void Start()
    {
        GetRotationValues();
        GetDirectionValues();

        ChangeDirection(_directionValues["right"]);
    }

    private void Update()
    {
        Inputs();

        _moveTimer += Time.deltaTime;

        if (_moveTimer >= _moveQueue)
        {
            _nextPosition = LevelGenerator.grid2D.GetWorldPos(_currentDirection);
            _snakeMovement.MoveSnake(_nextPosition);
            _moveTimer = 0f;
        }
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.W) && _currentDirection != _directionValues["down"])
        {
            ChangeDirection(_directionValues["up"]);
        }
        if (Input.GetKeyDown(KeyCode.S) && _currentDirection != _directionValues["up"])
        {
            ChangeDirection(_directionValues["down"]);
        }
        if (Input.GetKeyDown(KeyCode.D) && _currentDirection != _directionValues["left"])
        {
            ChangeDirection(_directionValues["right"]);
        }
        if (Input.GetKeyDown(KeyCode.A) && _currentDirection != _directionValues["right"])
        {
            ChangeDirection(_directionValues["left"]);
        }
    }

    private void ChangeDirection(Vector2Int direction)
    {
        _currentDirection = direction;
        _nextRotation = Quaternion.Euler(_rotationValues[direction]);

        transform.rotation = _nextRotation;
    }

    private void GetRotationValues()
    {
        _rotationValues = new Dictionary<Vector2Int, Vector3Int>();
        _rotationValues.Add(new Vector2Int(0, 1), new Vector3Int(0, 0, 90));
        _rotationValues.Add(new Vector2Int(0, -1), new Vector3Int(0, 0, -90));
        _rotationValues.Add(new Vector2Int(1, 0), new Vector3Int(0, 0, 0));
        _rotationValues.Add(new Vector2Int(-1, 0), new Vector3Int(0, 0, 180));
    }

    private void GetDirectionValues()
    {
        _directionValues = new Dictionary<string, Vector2Int>();
        _directionValues.Add("left", new Vector2Int(-1, 0));
        _directionValues.Add("right", new Vector2Int(1, 0));
        _directionValues.Add("up", new Vector2Int(0, 1));
        _directionValues.Add("down", new Vector2Int(0, -1));
    }
}
