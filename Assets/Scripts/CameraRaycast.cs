using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public int hits;
    public Vector3 targetPoint;
    private Camera _camera;
    private Ray _ray;

    private void Awake()
    {
        _camera = gameObject.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if ((Input.GetMouseButtonUp(0) | Input.touchCount > 0) & hits == 0)
        {
            CheckPlatform();
            if (Physics.Raycast(_ray, out var hit, 10f, layerMask))
            {
                targetPoint = hit.point;
                hits += 1;
            }
        }
    }

    private void CheckPlatform()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer |
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            _ray = _camera.ScreenPointToRay(Input.GetTouch(0).deltaPosition);
        }
    }
}