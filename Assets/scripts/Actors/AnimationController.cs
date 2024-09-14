using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject viz;
    public float slashRange = 40f;
    public float slashAngle = 90f;
    public float turnSpeedThreshold = 3;

    Animator animator;
    Rigidbody rb;
    Vector3 targetDirection;

    [SerializeField] LayerMask enemyMask;



    public float turnSpeed = 0.1f;

    enum JumpState
    {
        Grounded,
        Up,
        Idle,
        Down
    }

    JumpState jumpState = JumpState.Grounded;
    public float jumpIdleVelocityThreshold = 0.1f;
    public float jumpEndVelocityThreshold = 0.1f;

    int attackingHash;
    int speedHash;
    int jumpStartHash;
    int jumpIdleHash;
    int jumpEndHash;

    Vector3 attackVelocitySave;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();
        attackingHash = Animator.StringToHash("attack");
        speedHash = Animator.StringToHash("speed");
        jumpStartHash = Animator.StringToHash("jumpStart");
        jumpIdleHash = Animator.StringToHash("jumpIdle");
        jumpEndHash = Animator.StringToHash("jumpEnd");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity;
        float verticalSpeed = velocity.y;
        velocity.y = 0;
        float speed = velocity.magnitude;
        animator.SetFloat(speedHash, speed);

        viz.transform.forward = Vector3.RotateTowards(viz.transform.forward, targetDirection, turnSpeed*Time.deltaTime, 0.0f);

        handleJump(verticalSpeed);

    }

    public void SetTargetDirection(Vector2 targetDir)
    {
        targetDirection = targetDir.To3d();
    }

    void handleJump(float verticalSpeed)
    {
        if (jumpState == JumpState.Up)
        {
            if (Mathf.Abs(verticalSpeed) < jumpIdleVelocityThreshold)
            {
                jumpState = JumpState.Idle;
                animator.SetTrigger(jumpIdleHash);
                Debug.Log("Idle Triggerd");
            }
        }
        else if (jumpState == JumpState.Idle)
        {
            if (verticalSpeed < -jumpEndVelocityThreshold)
            {
                jumpState = JumpState.Down;
                animator.SetTrigger(jumpEndHash);

                Debug.Log("End Triggerd");
            }
        }
        else if (jumpState == JumpState.Down || jumpState == JumpState.Idle)
        {
            if (verticalSpeed < 0.001f)
            {
                jumpState = JumpState.Grounded;
                Debug.Log("Grounded");
            }
        }
    }

    public void OnAttack()
    {
        animator.SetTrigger(attackingHash);

    }

    public void OnJump()
    {
        animator.SetTrigger(jumpStartHash);
        jumpState = JumpState.Up;
    }

    public void AnimDealDamage()
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

    public void AnimOnAttackStart()
    {
        attackVelocitySave = rb.velocity;
        rb.velocity = Vector3.zero;
    }

    public void AnimOnAttackFinish()
    {
        rb.velocity = attackVelocitySave;
    }
}
