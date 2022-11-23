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

    public float maxViewAngle = 60f;

    public Gun activeGun;
    public List<Gun> gunList = new List<Gun>();
    public int currentGun;

    public Transform adsPoint, gunHolder;
    private Vector3 gunstartPosition;
    public float adsSpeed;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentGun--;
        SwitchGun();

        gunstartPosition = gunHolder.localPosition;
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

        if (charController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityStrength * Time.deltaTime;
        }

        canJump = Physics.OverlapSphere(groundCheckPoint.position, 0.25f, whatsGround).Length > 0;

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            moveInput.y = jumpForce;
        }

        charController.Move(moveInput * Time.deltaTime);

        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSens;

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

        if (camTransform.rotation.eulerAngles.x > maxViewAngle && camTransform.rotation.eulerAngles.x < 100f)
        {
            camTransform.rotation = Quaternion.Euler(maxViewAngle, camTransform.rotation.eulerAngles.y, camTransform.rotation.eulerAngles.z);
        }
        else if (camTransform.rotation.eulerAngles.x > 180f && camTransform.rotation.eulerAngles.x < 360f - maxViewAngle)
        {
            camTransform.rotation = Quaternion.Euler(-maxViewAngle, camTransform.rotation.eulerAngles.y, camTransform.rotation.eulerAngles.z);
        }

        //handle shooting
        /*
         * Single shots
         */
        if (Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0)
        {
            RaycastHit hit;
            source.PlayOneShot(clip);

            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, 60f))
            {
                if (Vector3.Distance(camTransform.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(camTransform.position + (camTransform.forward * 30f));
            }
            // Instantiate(bullet, firePoint.position, firePoint.rotation);
            FireBullet();
        }

        /*
         * Repeating Shots
         */
        if (Input.GetMouseButton(0) && activeGun.canAutoFire)
        {
            if (activeGun.fireCounter <= 0)
                FireBullet();
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchGun();
        }

        if(Input.GetMouseButtonDown(1))
        {
            CameraController.instance.ZoomIn(activeGun.zoomAmmount);
        }
        if(Input.GetMouseButton(1))
        {
            gunHolder.position = Vector3.MoveTowards(gunHolder.position, adsPoint.position, adsSpeed * Time.deltaTime);
        }
        else
        {
            gunHolder.localPosition = Vector3.MoveTowards(gunHolder.localPosition, gunstartPosition, adsSpeed * Time.deltaTime);
        }

        if(Input.GetMouseButtonUp(1))
        {
            CameraController.instance.ZoomOut();
        }

        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("onGround", canJump);
    }

    public void FireBullet()
    {
        if (activeGun.currentAmmo > 0)
        {
            activeGun.currentAmmo--;


            Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);

            activeGun.fireCounter = activeGun.fireRate;

            UIController.instance.ammoText.text = "AMMO: " + activeGun.currentAmmo;
        }
    }

    public void SwitchGun()
    {
        activeGun.gameObject.SetActive(false);
        currentGun++;

        if(currentGun >= gunList.Count)
        {
            currentGun = 0;
        }

        activeGun = gunList[currentGun];
        activeGun.gameObject.SetActive(true);

        UIController.instance.ammoText.text = "AMMO: " + activeGun.currentAmmo;
        firePoint.position = activeGun.firePoint.position;
    }

}
