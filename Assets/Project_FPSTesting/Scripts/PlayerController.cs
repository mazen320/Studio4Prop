using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float moveSpeed, gravityStrength, jumpForce, runSpeed;
    public CharacterController charController;

    private Vector3 moveInput;
    public AudioSource source;
    public AudioClip clip;

    public Transform camTransform;

    public float mouseSens;
    public bool invertX;
    public bool invertY;

    private bool canJump;
    public Transform groundCheckPoint;
    public LayerMask whatsGround;

    public Animator anim;

    public GameObject bullet;
    public Transform firePoint;

    private void Awake()
    {
        instance = this;
    }

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

        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTransform.rotation = Quaternion.Euler(camTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        //handle shooting
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            source.PlayOneShot(clip);

            if(Physics.Raycast(camTransform.position, camTransform.forward, out hit, 60f))
            {
                if (Vector3.Distance(camTransform.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(camTransform.position + camTransform.forward * 30f); 
            }
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("onGround", canJump);
    }
}
