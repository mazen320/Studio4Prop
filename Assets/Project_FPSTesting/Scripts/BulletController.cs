using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed, lifeTime;
    public Rigidbody bulletRB;

    public GameObject impactEffect;

    public int damage = 1;

    void Update()
    {
        bulletRB.velocity = transform.forward * bulletSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
        }

        Destroy(gameObject);
        Instantiate(impactEffect, transform.position + (transform.forward * (-bulletSpeed * Time.deltaTime)), transform.rotation);
    }
}
