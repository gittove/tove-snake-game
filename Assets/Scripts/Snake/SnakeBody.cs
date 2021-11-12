using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public SnakeList<GameObject> _snakeList;
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
        _snakeList = new SnakeList<GameObject>();
        _tail = Instantiate(_tailPrefab, this.transform.position, Quaternion.identity);
        _snakeList.CreateBody(this.gameObject, _tail);
    }
    
    void AddBodyPart()
    {
        Transform tailTransform = _snakeList.GetTailTransform;
        _body = Instantiate(_bodyPrefab1, tailTransform.position, tailTransform.rotation);
        _snakeList.Add(_body);
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
