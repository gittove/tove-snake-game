using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private int _gridIndexX;
    private int _gridIndexY;
    private int _nextIndexX;
    private int _nextIndexY;
    private Vector2 _gridSize;
    private Vector2 _nextPosition;
    [SerializeField] private GameObject _levelManager;
    private SnakeBody _snakeBody;
    private GameState _gameState;

    private void Awake()
    {
        _snakeBody = GetComponent<SnakeBody>();
        _gameState = _levelManager.GetComponent<GameState>();
    }

    private void Start()
    {
        _gridIndexX = 0;
        _gridIndexY = 0;
        _gridSize = LevelGenerator.gridSize;
        transform.position = LevelGenerator.gridSpaces[_gridIndexY, _gridIndexX];
    }

    public void MoveSnake(Vector2 currentDirection)
    {
        _gridIndexX += Mathf.RoundToInt(currentDirection.x);
        _gridIndexY += Mathf.RoundToInt(currentDirection.y);
        
        _nextIndexX = WrapPosition(_gridIndexX, 0, Mathf.RoundToInt(_gridSize.x));
        _nextIndexY = WrapPosition(_gridIndexY, 0, Mathf.RoundToInt(_gridSize.y));
        _nextPosition = LevelGenerator.gridSpaces[_nextIndexY, _nextIndexX];
        
        _gameState.CheckForGameOver(_nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, _nextPosition);
        transform.position = _nextPosition;
    }

    private int WrapPosition(int currentValue, float addValue, int max)
    {
        return Mathf.RoundToInt(((currentValue + addValue) % max+max) % max);
    }
}
