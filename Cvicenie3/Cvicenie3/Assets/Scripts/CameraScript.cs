using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Player player;
    
    private void Update()
    {
        if (Input.GetMouseButton(2))
        {
            player.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);
        }
    }
}