using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private GameObject _levelManager;
    private Vector2 _gridSize;
    private SnakeBody _snakeBody;
    private GameState _gameState;
    private Dictionary<Vector3, Vector3> _rotationValues;

    private void Awake()
    {
        _snakeBody = GetComponent<SnakeBody>();
        _gameState = _levelManager.GetComponent<GameState>();
    }

    private void Start()
    {
        _gridSize = LevelGenerator.gridSize;
        transform.position = Vector3.zero;

        _rotationValues = new Dictionary<Vector3, Vector3>();
        _rotationValues.Add(new Vector3(0, 1, 0), new Vector3(0, 0, 90));
        _rotationValues.Add(new Vector3(0, -1, 0), new Vector3(0, 0, -90));
        _rotationValues.Add(new Vector3(1, 0, 0), new Vector3(0, 0, 0));
        _rotationValues.Add(new Vector3(-1, 0, 0), new Vector3(0, 0, 180));
    }

    public void MoveSnake(Vector3 nextPosition)
    {
        Vector3 direction = nextPosition - transform.position;

       // _nextPosition = WrapPosition(transform.position+direction);
       // _nextPositionX = WrapPosition(transform.position.x, (int)direction.x, (int)_gridSize.x);
       // _nextPositionY = WrapPosition(transform.position.y, (int)direction.y, (int)_gridSize.y);
       // _nextPosition = new Vector3(_nextPositionX, _nextPositionY, 0f);

        _gameState.CheckForGameOver(nextPosition);

        _snakeBody.snakeList.MoveNodes(transform, nextPosition);
        transform.position = nextPosition;
        transform.rotation = Quaternion.Euler(_rotationValues[direction]);
    }

    public Vector3 WrapPosition(Vector3 nextPos)
    {
        nextPos.x = Wrap((int)nextPos.x, 0, (int)_gridSize.x);
        nextPos.y = Wrap((int)nextPos.y, 0, (int)_gridSize.y);

        return nextPos;
    }
    
    private int Wrap(int i, int inclusiveMin, int exclusiveMax)
    {
        int distance = exclusiveMax - inclusiveMin;
        int rest = ((i + distance) % distance) + inclusiveMin;
        return rest;
    }
    /*
    private float WrapPosition(float currentValue, int addValue, int max)
    {
        return ((currentValue + addValue) % max+max) % max;
    }
    */
}
