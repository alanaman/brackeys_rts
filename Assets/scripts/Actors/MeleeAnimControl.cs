using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAnimControl : MonoBehaviour
{
    [SerializeField] GameObject viz;
    Animator animator;
    Rigidbody rb;
    public float turnSpeed = 0.1f;
    Vector3 targetPosition;

    int attackingHash;
    int speedHash;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();
        attackingHash = Animator.StringToHash("attack");
        speedHash = Animator.StringToHash("speed");
    }

    void Update()
    {
        Vector3 velocity = rb.velocity;
        float verticalSpeed = velocity.y;
        velocity.y = 0;
        float speed = velocity.magnitude;
        animator.SetFloat(speedHash, speed);

        Vector3 forwardTarget;
        if (speed > 0.1f)
        {
            forwardTarget = velocity.To2D();
        }
        else
        {
            forwardTarget = targetPosition.To2D() - transform.position.To2D();
        }
        viz.transform.forward = Vector3.RotateTowards(viz.transform.forward, forwardTarget, turnSpeed, 0.0f);

    }

    public void OnAttack()
    {
        animator.SetTrigger(attackingHash);

    }

    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
    }
}
