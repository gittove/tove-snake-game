using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraSizeToScreen : MonoBehaviour
{
    private float _targetAspect;
    private float _screenAspect;
    private float _viewportHeight;
    private Camera camera;

    public void SetCameraSize()
    {
            _targetAspect = 16.0f / 9.0f;
            _screenAspect = (float)Screen.width / (float)Screen.height;
            _viewportHeight = _screenAspect / _targetAspect;
            camera = GetComponent<Camera>();

            if (_viewportHeight < 1.0f)
            {
                Rect rect = camera.rect;

                rect.width = 1.0f;
                rect.height = _viewportHeight;
                rect.x = 0;
                rect.y = (1.0f - _viewportHeight) / 2.0f;

                camera.rect = rect;
            }
            else
            {
                float scalewidth = 1.0f / _viewportHeight;

                Rect rect = camera.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

                camera.rect = rect;
            }
    }
}
