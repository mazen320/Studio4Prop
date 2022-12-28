using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody rb;

    private bool chasing;
    public float disToChase = 10f, disToLose = 15f, disToStop = 2f;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;

    public float keepChasingTime;
    float chaseCounter;

    void Start()
    {
        startPoint = transform.position;
    }

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

            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;
            }

            if (chaseCounter <= 0)
            {
                agent.destination = startPoint;
            }
        }
        else
        {
            // transform.LookAt(targetPoint);

            // rb.velocity = transform.forward * moveSpeed;

            if (Vector3.Distance(transform.position, targetPoint) > disToStop)
            {
                agent.destination = targetPoint;
            }
            else
            {
                agent.destination = transform.position;
            }

            if (Vector3.Distance(transform.position, targetPoint) > disToLose)
            {
                chasing = false;

                chaseCounter = keepChasingTime;
            }
        }
    }
}
