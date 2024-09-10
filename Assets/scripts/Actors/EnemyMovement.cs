using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float distanceFromTarget = 1.5f;

    NavMeshAgentUtil nma;

    Transform _target;

    // Start is called before the first frame update
    void Start()
    {
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
            return;
        }

        NavMeshPath path = new NavMeshPath();
        Vector3 targetPos = _target.position;
        nma.CalculatePath(targetPos, path);
        if(path.corners.Length == 2)
        {
            Vector3 target = path.corners[1];
            target += (transform.position - target).normalized * distanceFromTarget;

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

    void TurnAndMove(Vector3 target)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (target.magnitude < 0.05f)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        rb.velocity = target.normalized * moveSpeed;
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
