using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private GameObject _levelManager;
    private int _gridWidth;
    private int _gridHeight;
    private float _nextPositionX;
    private float _nextPositionY;
    private Vector3 _nextPosition;
    private SnakeBody _snakeBody;
    private GameState _gameState;

    void Start()
    {
        _gridWidth = LevelGenerator.gridWidth;
        _gridHeight = LevelGenerator.gridHeight;
        _snakeBody = GetComponent<SnakeBody>();
        _gameState = _levelManager.GetComponent<GameState>();
        transform.position = Vector3.zero;
    }

    public void MoveSnake(Vector3Int direction)
    {
        _nextPositionX = WrapPosition(transform.position.x, direction.x, _gridWidth);
        _nextPositionY = WrapPosition(transform.position.y, direction.y, _gridHeight);
        _nextPosition = new Vector3(_nextPositionX, _nextPositionY, 0f);

        _gameState.CheckForGameOver(_nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, _nextPosition);
        transform.position = _nextPosition;
    }
    
    private float WrapPosition(float currentValue, int addValue, int max)
    {
        return ((currentValue + addValue) % max+max) % max;
    }
}
