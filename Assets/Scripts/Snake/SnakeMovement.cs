using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private int _gridIndexX;
    private int _gridIndexY;
    private float _nextPositionX;
    private float _nextPositionY;
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
        transform.position = LevelGenerator.gridSpaces[_gridIndexX, _gridIndexY];
    }

    public void MoveSnake(Vector2 currentDirection)
    {
        _gridIndexX += Mathf.RoundToInt(currentDirection.x);
        _gridIndexY += Mathf.RoundToInt(currentDirection.y);
        
        _nextPositionX = WrapPosition(LevelGenerator.gridSpaces[_gridIndexX, _gridIndexY].x, Mathf.RoundToInt(_gridSize.x));
        _nextPositionY = WrapPosition(LevelGenerator.gridSpaces[_gridIndexX, _gridIndexY].y, Mathf.RoundToInt(_gridSize.y));
        _nextPosition = new Vector2(_nextPositionX, _nextPositionY);
        
        _gameState.CheckForGameOver(_nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, _nextPosition);
        transform.position = _nextPosition;
    }

    private float WrapPosition(float value, int max)
    {
        return ((value) % max+max) % max;
    }
}
