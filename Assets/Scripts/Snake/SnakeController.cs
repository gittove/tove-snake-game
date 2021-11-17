using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private int index;
    private float _moveQueue;
    private float _moveTimer;
    private Vector3 _fruitPosition;
 //   private Vector3Int _currentDirection;
  //  private Vector3Int _currentRotation;
  //  private Vector3Int[] _directions = new Vector3Int[4] { Vector3Int.up, Vector3Int.down, Vector3Int.right, Vector3Int.left };
  //  private Vector3Int[] _rotations = new Vector3Int[4] { new Vector3Int(0, 0, 90), new Vector3Int(0, 0, -90), new Vector3Int(0, 0, 0), new Vector3Int(0, 0, 180) };
    private SnakeMovement _snakeMovement;
    private Pathfinder _pathfinder;
    private List<Tile> _currentPath;

    private void Awake()
    {
        index = 0;
        _moveQueue = 0.5f;
        _moveTimer = 0f;
        _snakeMovement = GetComponent<SnakeMovement>();
        _pathfinder = GetComponent<Pathfinder>();
    }

  /*  private void Start()
    {
        ChangeDirection(2);
    } */

    public void UpdateFruitPosition(Vector3 newPosition)
    {
        _fruitPosition = newPosition;
        _currentPath = _pathfinder.FindPath(transform.position, _fruitPosition);
        index = 0;
    }

    private void Update()
    {
      //  Inputs();

        _moveTimer += Time.deltaTime;

        if (_moveTimer >= _moveQueue)
        {
            // _snakeMovement.MoveSnake(_currentDirection);
            _snakeMovement.MoveSnake(_currentPath[index].position);
            _moveTimer = 0f;
            index++;
        }
    }
    /*
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
    */
}
