using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float mouseSpeed;
    PauseMenu pauseMenu;
    float yRotation;
    float xRotation;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * mouseSpeed;
        //
        //float xRotation = transform.eulerAngles.x + mouseInput.x;
        //
        //float clampedX = Mathf.Clamp(xRotation, -30f, 30f);
        //transform.eulerAngles = new Vector3(clampedX, transform.localEulerAngles.y + mouseInput.y, 0);
        if (!pauseMenu.isPaused())
        {
            yRotation -= mouseSpeed * Input.GetAxis("Mouse Y");
            xRotation = mouseSpeed * Input.GetAxis("Mouse X");

            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.eulerAngles = new Vector3(yRotation, transform.localEulerAngles.y + xRotation, 0);
        }
    }

    public void changeSensitivity(float value)
    {
        mouseSpeed = value;
    }

    //Input.GetAxis("Mouse Y")
}
