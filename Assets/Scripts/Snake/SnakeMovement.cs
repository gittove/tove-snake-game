using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float nextPositionX;
    private float nextPositionY;
    private Vector2 _gridSize;
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
        _gridSize = LevelGenerator.gridSize;
        transform.position = Vector3.zero;
    }

    public void MoveSnake(Vector3 nextPosition)
    {
        nextPositionX = WrapPosition(transform.position.x, Mathf.RoundToInt(nextPosition.x), Mathf.RoundToInt(_gridSize.x));
        nextPositionY = WrapPosition(transform.position.y, Mathf.RoundToInt(nextPosition.y), Mathf.RoundToInt(_gridSize.y));
        nextPosition = new Vector3(nextPositionX, nextPositionY, 0f);

        _gameState.CheckForGameOver(nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, nextPosition);
        transform.position = nextPosition;
    }

    private float CorrectEuler(float rotationValue)
    {
        while (rotationValue > 360)
        {
            rotationValue = rotationValue - 360;
        }
        while (rotationValue < 0)
        {
            rotationValue = rotationValue + 360;
        }

        return rotationValue;
    }
    
    private float WrapPosition(float currentValue, int addValue, int max)
    {
        return ((currentValue + addValue) % max+max) % max;
    }
    
}
