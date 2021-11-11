using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public SnakeList<GameObject> _snakeBody;
    [SerializeField] private GameObject _bodyPrefab1;
    [SerializeField] private GameObject _bodyPrefab2;
    [SerializeField] private GameObject _tailPrefab;
    private GameObject _tail;
    private GameObject _body;

    private void Awake()
    {
        CreateSnake();
    }

    void CreateSnake()
    {
        _snakeBody = new SnakeList<GameObject>();
        _snakeBody.Add(this.gameObject);
        _tail = Instantiate(_tailPrefab, this.transform.position, Quaternion.identity);
        _snakeBody.Add(_tail);
    }

    void AddBodyPart()
    {
        _body = Instantiate(_bodyPrefab1, this.transform.position, Quaternion.identity);
        _snakeBody.InsertBodyPart(_body);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Fruit"))
        {
            AddBodyPart();
        }

        else
        {
            //fix this later
            Debug.Log("U fuckin dead bro lmfao");
        }
    }
}
