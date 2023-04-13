using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float upDownSpeed;

    [SerializeField] private float mouseSensitivity;
    private Vector2 turn;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * upDownSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * -upDownSpeed);
        }

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else
        {
            Cursor.lockState= CursorLockMode.None;
        }
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0, Input.GetAxis("Vertical") * movementSpeed));
    }
}
