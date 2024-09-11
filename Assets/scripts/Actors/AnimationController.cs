using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject viz;

    Animator animator;
    Rigidbody rb;
    Vector3 targetDirection;

    public float turnSpeed = 0.1f;

    int walkingHash;
    int speedHash;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        walkingHash = Animator.StringToHash("walking");
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
            animator.SetBool(walkingHash, true);
        }
        else
        {
            animator.SetBool(walkingHash, false);
        }
        viz.transform.forward = Vector3.RotateTowards(viz.transform.forward, targetDirection, turnSpeed, 0.0f);
        
        
    }
}
