using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Archer : MonoBehaviour
{
    public LayerMask LayerMask;
    public GameObject arrow;
    public float timeBetweenAttacks = 1f;
    public float arrowSpeed = 10f;

    [SerializeField] Transform spawnPoint;

    float attacktimer;

    void Start()
    {
        attacktimer = timeBetweenAttacks;
    }

    GameObject currentTarget;

    void Update()
    {


        Collider[] colliders = Physics.OverlapSphere(transform.position, 25f, LayerMask);
        float minDist = Mathf.Infinity;
        currentTarget = null;

        foreach (Collider collider in colliders)
        {
            float dist = (collider.transform.position - transform.position).magnitude;
            if (dist < minDist)
            {
                currentTarget = collider.gameObject;
                minDist = dist;
            }
        }


        if (currentTarget != null)
        {
            //look at the nearest enemy
            transform.forward = currentTarget.transform.position - transform.position;

            attacktimer -= Time.deltaTime;
            if (attacktimer < 0)
            {
                attacktimer = timeBetweenAttacks;
                Fire();
            }
        }
    }

    void Fire()
    {
        Vector3 arrowDir = (currentTarget.transform.position - transform.position).normalized;
        InstantiateArrow();
    }

    void InstantiateArrow()
    {
        GameObject newArrow = Instantiate(arrow, spawnPoint.position, Quaternion.identity);
        Rigidbody arrowRb = newArrow.GetComponent<Rigidbody>();

        Vector3 arrowVelocity = CalculateVelocity(currentTarget.transform.position - spawnPoint.position, 45);

        arrowRb.velocity = arrowVelocity;
    }

    Vector3 CalculateVelocity(Vector3 target, float angle)
    {
        float x = Mathf.Sqrt(target.x * target.x + target.z * target.z);
        float y = target.y;
        // Constants
        float g = Physics.gravity.magnitude;

        // Convert angle to radians
        float angleRad = angle * Mathf.PI / 180;

        // Time of flight
        // Using the horizontal motion equation: t = x / (v * cos(theta))
        // Solve for time in terms of velocity:
        // v = sqrt(g * x^2 / (2 * cos^2(theta) * (x * tan(theta) - y)))
        float tanTheta = Mathf.Tan(angleRad);
        float cosTheta = Mathf.Cos(angleRad);

        // Calculating the required velocity
        float speed = Mathf.Sqrt((g * x * x) / (2 * cosTheta * cosTheta * (x * tanTheta - y)));

        Vector3 velocity = Vector3.zero;
        velocity.y = speed * Mathf.Sin(angleRad);

        float horizontalMagnitude = speed * Mathf.Cos(angleRad);
        velocity.x = horizontalMagnitude * target.x / x;
        velocity.z = horizontalMagnitude * target.z / x;

        return velocity;

    }
}
