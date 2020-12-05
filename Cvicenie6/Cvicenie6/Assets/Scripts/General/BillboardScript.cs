using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(_mainCamera.transform.forward + transform.position);
    }
}
