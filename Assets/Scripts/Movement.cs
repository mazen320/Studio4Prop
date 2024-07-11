using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 6f;
    public float groundCheckDistance = 1.1f;
    public LayerMask groundLayer;

    private Rigidbody rig;
    private Vector2 input;
    private Vector3 movementVector;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();

        rig.freezeRotation = true;
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        movementVector = (input.x * transform.right + input.y * transform.forward) * speed;

        rig.velocity = new Vector3(movementVector.x, rig.velocity.y, movementVector.z);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
