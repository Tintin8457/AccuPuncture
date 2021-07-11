using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseXSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private Dart_Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //Find player
         GameObject player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            shooter = player.GetComponent<Dart_Shooter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.gameOver == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
