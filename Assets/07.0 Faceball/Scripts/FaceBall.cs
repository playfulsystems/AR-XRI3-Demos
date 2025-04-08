using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBall : MonoBehaviour
{
    Vector3 targetPos = new Vector3(0, 0, 1f);
    float speed = 0.4f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 directionToTarget = targetPos - transform.position;
        rb.linearVelocity = directionToTarget.normalized * speed;
    }

    public void SetVelocityToTarget(Vector3 newVelocity)
	{
        targetPos = newVelocity;
        Vector3 directionToTarget = targetPos - transform.position;
        rb.linearVelocity = directionToTarget.normalized * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        rb.linearVelocity = Vector3.Reflect(rb.linearVelocity, collision.contacts[0].normal);
    }
}
