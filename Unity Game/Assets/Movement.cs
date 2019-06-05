using UnityEngine;

public class Movement : MonoBehaviour
{
    public float lookSpeedH = 2f;
    public float lookSpeedV = 2f;
    public float zoomSpeed = 2f;
    public float dragSpeed = 6f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        //Look around with Right Mouse
        if (Input.GetMouseButton(1))
        {
            yaw += lookSpeedH * Input.GetAxis("Mouse X");
            pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        //drag camera around with Middle Mouse
        if (Input.GetMouseButton(2))
        {
            transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
        }

        //Zoom in and out with Mouse Wheel
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        transform.Translate((Input.GetKey(KeyCode.A) ? -0.01f : 0) + (Input.GetKey(KeyCode.D) ? 0.01f : 0) * zoomSpeed, 0, (Input.GetAxis("Mouse ScrollWheel") + (Input.GetKey(KeyCode.S) ? -0.01f : 0) + (Input.GetKey(KeyCode.W) ? 0.01f : 0))* zoomSpeed, Space.Self);
    }
}
