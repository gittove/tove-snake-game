using UnityEngine;

public class GridSizeToCamera : MonoBehaviour
{
    int gridWidth;
    int gridHeight;
    private int offsetX = 1;
    private int offsetY = 2;
    private Vector3 topRightCameraCorner;
    private Vector3 edgeVector;
    [SerializeField] private GameObject mainCamera;

    public Tile[,] SetGridSize()
    {
        mainCamera.GetComponent<CameraSizeToScreen>().SetCameraSize();
        topRightCameraCorner = new Vector3(1, 1, Camera.main.nearClipPlane);
        edgeVector = Camera.main.ViewportToWorldPoint(topRightCameraCorner);

        gridWidth = (int)(edgeVector.x * 2) + offsetX;
        gridHeight = (int)(edgeVector.y * 2) + offsetY;

        Tile[,] arr = new Tile[gridWidth, gridHeight];
        return arr;
    }
}
