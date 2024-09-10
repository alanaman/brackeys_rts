using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    float damage = 1;
    float timer = 0f;
    public float arrowHeight = 5f;
    public float arrowSpeed = 3f;

    Transform target;
    Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * arrowSpeed;
        if (timer > 1f)
        {
            Destroy(gameObject);
        }
        transform.position = EvaluatePosition(timer);
        transform.forward = EvaluatePosition(timer + 0.001f) - transform.position;
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    Vector3 EvaluatePosition(float t)
    {
        Vector3 controlPoint = spawnPosition + Vector3.up * arrowHeight + (target.position - spawnPosition) * .5f;
        Vector3 ac = Vector3.Lerp(spawnPosition, controlPoint, t);
        Vector3 cb = Vector3.Lerp(controlPoint, target.position, t);

        return Vector3.Lerp(ac, cb, t);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.HitDamage(damage);
            Destroy(gameObject);
        }
    }
}
