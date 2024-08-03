using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float sensModifier = 1.0f;

    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX * sensModifier;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY * sensModifier;

        orientation.Rotate(0, mouseX, 0);
        transform.Rotate(-mouseY, 0, 0);
    }
}
