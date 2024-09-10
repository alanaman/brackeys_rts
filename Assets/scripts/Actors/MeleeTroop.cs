using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class MeleeTroop : MonoBehaviour
{
    public Health health;
    MeleeAttack meleeAttack;
    TargetChaseNav movement;

    private void Start()
    {
        health = GetComponent<Health>();
        meleeAttack = GetComponent<MeleeAttack>();
        movement = GetComponent<TargetChaseNav>();
    }

    private void Update()
    {
        //find nearest troop, building or player to target
        float minDist = Mathf.Infinity;
        GameObject target = null;

        List<EnemyEntity> entities = GameManager.I.GetEnemyEntities();
        for (int i = 0; i < entities.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, entities[i].transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                target = entities[i].gameObject;
            }
        }

        if (target != null)
        {
            meleeAttack.SetTarget(target);
            movement.SetTarget(target);
        }

    }


    public Health GetHealth() { return health; }
}
