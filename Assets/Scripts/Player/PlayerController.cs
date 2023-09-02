/* Author: Kalin
 * Comment: Any player control feature, including movement, camera-view, animator...
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public GameObject barrel;
    public float playerSpeed = 2.0f;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 0.0f;
    private float cameraRotY = 0.0f; // rotation around the up/y axis
    private float cameraRotX = 0.0f; // rotation around the right/x axis

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        Vector3 rot = transform.localRotation.eulerAngles;
        cameraRotY = rot.y;
        cameraRotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        LookAt();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirectionForward = Camera.main.transform.forward * verticalInput;
        Vector3 moveDirectionSide = Camera.main.transform.right * horizontalInput;

        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        Vector3 distance = direction * playerSpeed * Time.deltaTime;

        controller.Move(distance);
    }

    private void LookAt()
    {
        cameraRotY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        cameraRotX += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        cameraRotX = Mathf.Clamp(cameraRotX, -clampAngle, clampAngle); // limit rotate angle
        if (barrel)
        {
            cameraRotX += -90;
            barrel.transform.rotation = Quaternion.Euler(cameraRotX, cameraRotY, 0.0f);
        }
        else
        {
            Camera.main.transform.rotation = Quaternion.Euler(cameraRotX, cameraRotY, 0.0f);
        }
    }
}