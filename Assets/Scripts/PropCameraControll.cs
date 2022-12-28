using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCameraControll : MonoBehaviour
{
    public float rotSpeed;
    public Transform player, target;
    float mouseX, mouseY;
    bool freeLook;

    void Start()
    {
        //hide and Lock cursor
        freeLook = false;
      //  Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        if (Input.GetKeyDown(KeyCode.LeftAlt))
            freeLook = !freeLook;

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (!freeLook)
            player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
