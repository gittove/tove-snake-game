using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Vector2 _gridSize;
    [SerializeField] private GameObject _snakeHead;
    private SnakeController _snakeController;

    
    private void Start()
    {
        _snakeController = _snakeHead.GetComponent<SnakeController>();
        _gridSize = LevelGenerator.gridSize;
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        int randomX = Random.Range(0, (int)_gridSize.x);
        int randomY = Random.Range(0, (int)_gridSize.y);

        transform.position = new Vector3(randomX, randomY, 0);
        _snakeController.UpdateFruitPosition(transform.position);
    }
}
