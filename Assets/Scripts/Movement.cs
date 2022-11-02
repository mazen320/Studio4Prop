using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed, runSpeed, jumpStrength, groundCheckDistance;
    Rigidbody rb;
    bool grounded, floating;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        floating = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement;

        if (Physics.Raycast(transform.position, -transform.up, groundCheckDistance))
            grounded = true;
        else
            grounded = false;

        if (Input.GetKey(KeyCode.LeftShift))
            movement = new Vector3(horizontal, 0f, vertical) * runSpeed * Time.deltaTime;
        else
            movement = new Vector3(horizontal, 0f, vertical) * Speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            rb.AddForce(new Vector3(0, jumpStrength, 0), ForceMode.Impulse);

        if (!floating)
            transform.Translate(movement, Space.Self);

        if (Input.GetKeyDown(KeyCode.G))
        {
            rb.useGravity = !rb.useGravity;
            rb.velocity = Vector3.zero;
            floating = !floating;
        }
    }
}
