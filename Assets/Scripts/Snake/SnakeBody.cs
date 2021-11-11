using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private SnakeList<GameObject> _snakeBody;
    [SerializeField] private GameObject _bodyPrefab1;
    [SerializeField] private GameObject _bodyPrefab2;
    [SerializeField] private GameObject _tail;

    void Start()
    {
        CreateSnake();
    }

    void CreateSnake()
    {
        _snakeBody = new SnakeList<GameObject>();
        _snakeBody.Add(this.gameObject);
    }

    void AddBodyPart()
    {
        _snakeBody.Add(_bodyPrefab1);
    }
    // todo AddBodyPart() -> call method when snek eats snack, add body prefab to _snakeBody

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Fruit")
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
