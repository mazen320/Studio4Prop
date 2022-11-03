using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed, gravityStrength;
    public CharacterController charController;

    private Vector3 moveInput;

    public Transform camTransform;

    public float mouseSens;
    public bool invertX;
    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float yStore = moveInput.y;

        Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = horizontalMove + verticalMove;
        moveInput.Normalize();
        moveInput = moveInput * moveSpeed;

        moveInput.y = yStore;

        moveInput.y += Physics.gravity.y * gravityStrength * Time.deltaTime;

        if(charController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityStrength * Time.deltaTime;
        }


        charController.Move(moveInput * Time.deltaTime);

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTransform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
    }
}
