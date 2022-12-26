
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6;
    public float jumpForce = 6;
    private Rigidbody rig;
    private Vector2 input;
    private Vector3 movementVector;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        //Need to freez rotation so the player do not flip over
        rig.freezeRotation = true;
    }
    private void Update()
    {
        //Cleanerway to get input
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        //Keep the movement vector aligned with the player rotation
        movementVector = input.x * transform.right * speed + input.y * transform.forward * speed;
        //Apply the movement vector to the rigidbody without effecting gravity
        rig.velocity = new Vector3(movementVector.x, rig.velocity.y, movementVector.z);
    }
    private bool IsGrounded()
    {
        //Simple way to check for ground
        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

