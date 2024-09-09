using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float damage = 1;

    //TODO: add logic to delete if it goes too far without hitting anything

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.HitDamage(damage);
            Destroy(gameObject);
        }
    }
}
