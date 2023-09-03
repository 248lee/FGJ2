/* Author: Kalin
 * Comment: Any player control feature, including movement, camera-view, animator...
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // for moving
    public float playerSpeed = 2.0f;
    public GameObject barrel;

    // for rotating view
    public float mouseSensitivity = 200.0f;
    public float clampAngle = 0.0f;
    private float cameraRotY = 0.0f; // rotation around the up/y axis
    private float cameraRotX = 0.0f; // rotation around the right/x axis

    // for fire
    public GameObject bulletPrefab;
    public GameObject bulletPoint;
    public float bulletSpeed = 5f;
    public float destroyTime = 1f;

    // for HP
    public int playerHP = 6;
    [SerializeField] GameObject HPIcon;
    [SerializeField] GameObject playerHPUI;

    private void Start()
    {

        Vector3 rot = transform.localRotation.eulerAngles;
        cameraRotY = rot.y;
        cameraRotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;

        AddHP(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mosue LB
            Fire();
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

        GetComponent<Rigidbody>().velocity = distance;
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

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
        Destroy(bullet, destroyTime);
    }

    //HP
    public void DropHP(int droppedHP)
    {
        playerHP -= droppedHP;
        for (int i = playerHPUI.transform.childCount; i > playerHP; i--)
        {
            //Debug.Log("playerHPUI" + playerHPUI.transform.childCount);
            if (i - 1 >= 0) Destroy(playerHPUI.transform.GetChild(i - 1).gameObject);
        }
    }
    public void AddHP(int addedHP)
    {
        playerHP += addedHP;
        while (playerHPUI.transform.childCount < playerHP)
        {
            Instantiate(HPIcon, playerHPUI.transform);
        }
    }
}
