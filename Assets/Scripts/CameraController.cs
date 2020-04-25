using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player_transform;
    [SerializeField] private float mouse_sensitivity;
    
    private float x_rotation = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        // Mouse controls
        var mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity;
        var mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity;

        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        player_transform.Rotate(Vector3.up * mouse_x);
    }
}
