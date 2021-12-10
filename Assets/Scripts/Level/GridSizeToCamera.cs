using UnityEngine;

public class GridSizeToCamera : MonoBehaviour
{
    private int _gridWidth;
    private int _gridHeight;
    private int _offsetX;
    private int _offsetY;
    private Vector3 _topRightCameraCorner;
    private Vector3 _edgeVector;
    [SerializeField] private GameObject _mainCamera;

    private void Start()
    {
        _offsetX = 1;
        _offsetY = 2;
    }

    public Vector2Int SetGridSize()
    {
        _mainCamera.GetComponent<CameraSizeToScreen>().SetCameraSize();
        _topRightCameraCorner = new Vector3(1f, 1f, Camera.main.nearClipPlane);
        _edgeVector = Camera.main.ViewportToWorldPoint(_topRightCameraCorner);

        _gridWidth = Mathf.RoundToInt(_edgeVector.x * 2) + _offsetX;
        _gridHeight = Mathf.RoundToInt(_edgeVector.y * 2) + _offsetY;

        Vector2Int gridSize = new Vector2Int(_gridWidth, _gridHeight);
        return gridSize;
    }
}
