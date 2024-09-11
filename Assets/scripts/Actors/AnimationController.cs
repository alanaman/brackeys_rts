using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject viz;
    public float slashRange = 40f;
    public float slashAngle = 90f;

    Animator animator;
    Rigidbody rb;
    Vector3 targetDirection;

    [SerializeField] LayerMask enemyMask;

    public float turnSpeed = 0.1f;

    int attackingHash;
    int speedHash;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();
        attackingHash = Animator.StringToHash("attack");
        speedHash = Animator.StringToHash("speed");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = 0;
        float speed = velocity.magnitude;
        animator.SetFloat(speedHash, speed);

        if (speed > 0.1f)
        {
            targetDirection = velocity.normalized;
        }
        viz.transform.forward = Vector3.RotateTowards(viz.transform.forward, targetDirection, turnSpeed, 0.0f);
    }

    public void OnAttack()
    {
        animator.SetTrigger(attackingHash);
    }

    public void DealDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, slashRange, enemyMask);
        Vector3 myPos = transform.position.To2D();
        foreach (Collider collider in colliders)
        {
            Vector3 targetPos = collider.transform.position.To2D();
            float threshold = Mathf.Cos(Mathf.Deg2Rad * slashAngle / 2);
            if (Vector3.Dot((targetPos - myPos).normalized, viz.transform.forward.To2D().normalized) > threshold)
                collider.GetComponent<Health>()?.HitDamage(5);
        }
    }
}
