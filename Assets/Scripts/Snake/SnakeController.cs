using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private float _moveQueue;
    private float _moveTimer;
    private Quaternion _nextRotation;
    private Vector2 _currentDirection;
    private SnakeMovement _snakeMovement;
    private Dictionary<string, Vector2> _directionValues;
    private Dictionary<Vector2, Vector3> _rotationValues;

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
            _snakeMovement.MoveSnake(_currentDirection);
            _moveTimer = 0f;
        }
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.W) && _currentDirection != _directionValues["down"])
        {
            Debug.Log("up");
            ChangeDirection(_directionValues["up"]);
        }
        if (Input.GetKeyDown(KeyCode.S) && _currentDirection != _directionValues["up"])
        {
            Debug.Log("down");
            ChangeDirection(_directionValues["down"]);
        }
        if (Input.GetKeyDown(KeyCode.D) && _currentDirection != _directionValues["left"])
        {
            Debug.Log("right");
            ChangeDirection(_directionValues["right"]);
        }
        if (Input.GetKeyDown(KeyCode.A) && _currentDirection != _directionValues["right"])
        {
            Debug.Log("left");
            ChangeDirection(_directionValues["left"]);
        }
    }

    private void ChangeDirection(Vector2 direction)
    {
        _currentDirection = direction;
        _nextRotation = Quaternion.Euler(_rotationValues[direction]);

        transform.rotation = _nextRotation;
    }

    private void GetRotationValues()
    {
        _rotationValues = new Dictionary<Vector2, Vector3>();
        _rotationValues.Add(new Vector2(0f, 1f), new Vector3(0f, 0f, 90f));
        _rotationValues.Add(new Vector2(0f, -1f), new Vector3(0f, 0f, -90f));
        _rotationValues.Add(new Vector2(1f, 0f), new Vector3(0f, 0f, 0f));
        _rotationValues.Add(new Vector2(-1f, 0f), new Vector3(0f, 0f, 180f));
    }

    private void GetDirectionValues()
    {
        _directionValues = new Dictionary<string, Vector2>();
        _directionValues.Add("left", new Vector2(-1f, 0f));
        _directionValues.Add("right", new Vector2(1f, 0f));
        _directionValues.Add("up", new Vector2(0f, 1f));
        _directionValues.Add("down", new Vector2(0f, -1f));
    }
}
