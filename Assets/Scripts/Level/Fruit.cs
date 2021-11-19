using UnityEngine;
using System.Collections.Generic;

public class Fruit : MonoBehaviour
{
    private Vector2 _gridSize;
    [SerializeField] private GameObject _snakeHead;
    private SnakeController _snakeController;
    private SnakeBody _snakeBody;
    private SnakeList<GameObject> _snakeList;

    
    private void Start()
    {
        _snakeController = _snakeHead.GetComponent<SnakeController>();
        _snakeBody = _snakeHead.GetComponent<SnakeBody>();
        _snakeList = _snakeBody.snakeList;
        _gridSize = LevelGenerator.gridSize;
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        HashSet<Vector3> snakeBodyPositions = _snakeList.GetBodyPositions;
        int randomX = Random.Range(0, (int)_gridSize.x);
        int randomY = Random.Range(0, (int)_gridSize.y);

        if(snakeBodyPositions.Contains(new Vector3(randomX, randomY, 0)))
        {
            RandomizePosition();
        }

        transform.position = new Vector3(randomX, randomY, 0);
        _snakeController.UpdateFruitPosition(transform.position);
    }
}
