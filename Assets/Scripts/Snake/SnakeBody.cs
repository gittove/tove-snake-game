using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public SnakeList<GameObject> snakeList;

    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private GameObject _tailPrefab;
    private Sprite _bodySprite;
    private Sprite _tailSprite;
    private GameObject _body;
    private GameObject _tail;

    private void Awake()
    {
        _bodySprite = _bodyPrefab.GetComponent<SpriteRenderer>().sprite;
        _tailSprite = _tailPrefab.GetComponent<SpriteRenderer>().sprite;
        CreateSnake();
    }

    private void CreateSnake()
    {
        snakeList = new SnakeList<GameObject>(_bodySprite, _tailSprite);
        _tail = Instantiate(_tailPrefab, new Vector3(-1, 0, 0), Quaternion.identity);
        snakeList.CreateBody(this.gameObject, _tail);
    }
    
    private void AddBodyPart()
    {
        Transform tailTransform = snakeList.GetTailTransform;
        _body = Instantiate(_bodyPrefab, tailTransform.position, tailTransform.rotation);
        snakeList.Add(_body);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Fruit"))
        {
            AddBodyPart();
        }
    }
}
