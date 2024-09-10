using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public Health health;
    MeleeAttack meleeAttack;
    EnemyMovement enemyMovement;

    private void Start()
    {
        health = GetComponent<Health>();
        meleeAttack = GetComponent<MeleeAttack>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        //find nearest troop, building or player to target
        float minDist = Mathf.Infinity;
        GameObject target = null;
        
        List<AllyEntity> entities = GameManager.I.GetAllyEntities();
        for(int i = 0; i < entities.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, entities[i].transform.position);
            if(dist < minDist)
            {
                minDist = dist;
                target = entities[i].gameObject;
            }
        }

        if(target != null)
        {
            meleeAttack.SetTarget(target);
            enemyMovement.SetTarget(target);
        }

    }


    public Health GetHealth() { return health; }
}