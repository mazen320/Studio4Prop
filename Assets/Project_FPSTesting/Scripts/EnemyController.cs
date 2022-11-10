using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody rb;

    private bool chasing;
    public float disToChase = 10f, disToLose = 15f;

    private Vector3 targetPoint;

    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < disToChase)
            {
                chasing = true;
            }
        }
        else
        {
            transform.LookAt(targetPoint);

            rb.velocity = transform.forward * moveSpeed;

            if(Vector3.Distance(transform.position, targetPoint) > disToLose)
            {
                chasing=false;
            }
        }
    }
}
