using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private float _moveQueue;
    private float _moveTimer;
    private Quaternion _nextRotation;
    private Vector3 _currentDirection;
    private SnakeMovement _snakeMovement;
    private Dictionary<Vector3, Vector3> _rotationValues;

    private void Awake()
    {
        _moveQueue = 0.2f;
        _moveTimer = 0f;
        _snakeMovement = GetComponent<SnakeMovement>();
    }

    private void Start()
    {

        _rotationValues = new Dictionary<Vector3, Vector3>();
        _rotationValues.Add(new Vector3(0, 1, 0), new Vector3(0, 0, 90));
        _rotationValues.Add(new Vector3(0, -1, 0), new Vector3(0, 0, -90));
        _rotationValues.Add(new Vector3(1, 0, 0), new Vector3(0, 0, 0));
        _rotationValues.Add(new Vector3(-1, 0, 0), new Vector3(0, 0, 180));

        ChangeDirection(new Vector3(1, 0, 0));
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeDirection(new Vector3(0, 1, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeDirection(new Vector3(0, -1, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeDirection(new Vector3(1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeDirection(new Vector3(-1, 0, 0));
        }
    }

    private void ChangeDirection(Vector3 direction)
    {
        _currentDirection = direction;
        _nextRotation = Quaternion.Euler(_rotationValues[direction]);

        transform.rotation = _nextRotation;
    }
}
