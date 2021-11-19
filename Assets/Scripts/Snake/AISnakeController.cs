using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISnakeController : MonoBehaviour
{
    private int index;
    private float _moveQueue;
    private float _moveTimer;
    private Vector3 _fruitPosition;
    [SerializeField] private GameObject _snake;
    private SnakeMovement _snakeMovement;
    private Pathfinder _pathfinder;
    private List<Tile> _currentPath;

    private void Awake()
    {
        index = 0;
        _moveQueue = 0.1f;
        _moveTimer = 0f;
        _snakeMovement = _snake.GetComponent<SnakeMovement>();
        _pathfinder = _snake.GetComponent<Pathfinder>();
    }

    public void UpdateFruitPosition(Vector3 newPosition)
    {
        _fruitPosition = newPosition;
        Debug.Log("New fruit position:" + _fruitPosition);
        _currentPath = _pathfinder.FindPath(transform.position, _fruitPosition);

        index = 0;
    }

    private void Update()
    {

        _moveTimer += Time.deltaTime;

        if (_moveTimer >= _moveQueue)
        {
            _snakeMovement.MoveSnake(_currentPath[index].position);
            _moveTimer = 0f;
            index++;

            if (transform.position == _currentPath[_currentPath.Count - 1].position)
            {
                _currentPath = _pathfinder.FindPath(transform.position, _fruitPosition);
            }
        }
    }
}
