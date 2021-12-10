using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2Int _startingGridIndex;
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
        _startingGridIndex = new Vector2Int(0, 0);
        transform.position = LevelGenerator.grid2D.GetWorldPos(_startingGridIndex);
    }

    public void MoveSnake(Vector2 nextPosition)
    {
        _gameState.CheckForGameOver(nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, nextPosition);
        transform.position = nextPosition;
    }
}
