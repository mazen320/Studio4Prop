using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed, gravityStrength, jumpForce, runSpeed;
    public CharacterController charController;

    private Vector3 moveInput;

    public Transform camTransform;

    public float mouseSens;
    public bool invertX;
    public bool invertY;

    private bool canJump;
    public Transform groundCheckPoint;
    public LayerMask whatsGround;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveInput.y;

        Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = horizontalMove + verticalMove;
        moveInput.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveInput = moveInput * runSpeed;
        }
        else
        {
            moveInput = moveInput * moveSpeed;
        }

        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityStrength * Time.deltaTime;

        if(charController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityStrength * Time.deltaTime;
        }

        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatsGround).Length > 0;

        //Jumping
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            moveInput.y = jumpForce;
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


        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("onGround", canJump);
    }
}
