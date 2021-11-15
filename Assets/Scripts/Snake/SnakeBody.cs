using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public GameObject tail;
    public SnakeList<GameObject> snakeList;

    [SerializeField] private GameObject _bodyPrefab1;
    [SerializeField] private GameObject _tailPrefab;
    private GameObject _body;

    private void Awake()
    {
        CreateSnake();
    }

    void CreateSnake()
    {
        snakeList = new SnakeList<GameObject>(_bodyPrefab1, _tailPrefab);
        tail = Instantiate(_tailPrefab, this.transform.position, Quaternion.identity);
        snakeList.CreateBody(this.gameObject, tail);
    }
    
    void AddBodyPart()
    {
        Transform tailTransform = snakeList.GetTailTransform;
        _body = Instantiate(_bodyPrefab1, tailTransform.position, tailTransform.rotation);
        snakeList.Add(_body);
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
