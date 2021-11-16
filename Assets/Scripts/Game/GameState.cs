using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private bool _gameOver;
    private SnakeBody _snakeBody;

    private void Start()
    {
        _snakeBody = GetComponent<SnakeBody>();
        _gameOver = false;
    }

    public void CheckForGameOver(Vector3 nextHeadPosition)
    {
        _gameOver = _snakeBody.snakeList.CheckForCollision(nextHeadPosition);

        if (_gameOver)
        {
            Debug.Log("u crashed into urself lol how embarrassing");
        }
    }
}
