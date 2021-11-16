using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private bool _gameOver;
    [SerializeField] private SnakeBody _snakeBody;

    private void Start()
    {
        _gameOver = false;
    }

    public void CheckForGameOver(Vector3 nextHeadPosition)
    {
        _gameOver = _snakeBody.snakeList.CheckForCollision(nextHeadPosition);

        if (_gameOver)
        {
            SceneManager.LoadScene(1);
        }
    }
}
