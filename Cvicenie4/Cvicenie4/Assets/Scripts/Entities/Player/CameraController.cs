using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Player player;
    
    private void Update()
    {
        if (Input.GetMouseButton(2))
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);
        }
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}