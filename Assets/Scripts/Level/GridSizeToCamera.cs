using UnityEngine;

public class GridSizeToCamera : MonoBehaviour
{
    int gridWidth;
    int gridHeight;
    int gridDepth;
    private int spriteOffset = 1;
    private Vector3 topRightCameraCorner;
    private Vector3 edgeVector;
    [SerializeField] private GameObject mainCamera;

    public GameObject[,] SetGridSize()
    {
        mainCamera.GetComponent<CameraSizeToScreen>().SetCameraSize();
        topRightCameraCorner = new Vector3(1, 1, Camera.main.nearClipPlane);
        edgeVector = Camera.main.ViewportToWorldPoint(topRightCameraCorner);

        gridWidth = (int)(edgeVector.x * 2) + spriteOffset;
        gridHeight = (int)(edgeVector.y * 2) + spriteOffset;
        gridDepth = (int)(edgeVector.z * 2) + spriteOffset;

        GameObject [,] arr = new GameObject[gridWidth, gridHeight];
        return arr;
    }
}
