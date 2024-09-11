using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetChaseNav : MonoBehaviour
{
    public float moveSpeed = 2;
    public float characterRange = 1.5f;

    NavMeshAgentUtil nma;
    Rigidbody rb;

    Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nma = GetComponentInChildren<NavMeshAgentUtil>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            StopMoving();
            return;
        }
        float distanceFromTarget = Vector3Ext.Distance2D(transform.position, _target.position);

        if(distanceFromTarget<=characterRange)
        {
            StopMoving();
            return;
        }

        NavMeshPath path = new NavMeshPath();
        Vector3 targetPos = _target.position;
        nma.CalculatePath(targetPos, path);
        if(path.corners.Length == 2)
        {
            Vector3 target = path.corners[1];
            target += (transform.position - target).To2D().normalized * characterRange;

            TurnAndMove(target - transform.position);
        }
        else if(path.corners.Length > 2)
        {
            Vector3 target = path.corners[1];
            TurnAndMove(target - transform.position);
        }
        else
        {
            TurnAndMove(Vector3.zero);
        }
    }

    void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }

    void TurnAndMove(Vector3 target)
    {
        target = target.To2D();
        if (target.magnitude < 0.05f)
        {
            target = Vector3.zero;
            target.y = rb.velocity.y;
            rb.velocity = target;
            return;
        }

        target = target.normalized * moveSpeed;
        target.y = rb.velocity.y;
        rb.velocity = target;
    }

    public void SetTarget<T>(T target) where T : MonoBehaviour
    {
        _target = target.transform;
    }

    public void SetTarget(GameObject target)
    {
        _target = target.transform;
    }
}
