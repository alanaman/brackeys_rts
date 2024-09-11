
using UnityEngine;
using UnityEngine.Rendering.UI;

public class MeleeAttack: MonoBehaviour
{
    Health targetHealth;
    public float attackDamage = 10f;
    public float attackRange = 2f;
    public float attackRate = 1f;

    private float nextAttackTime = 0f;

    private void Update()
    {
        nextAttackTime -= Time.deltaTime;
        nextAttackTime = Mathf.Max(nextAttackTime, 0);

        if(targetHealth == null)
        {
            return;
        }
        else if(TargetInRange())
        {

            if(nextAttackTime <= 0)
            {
                Attack();
                nextAttackTime = attackRate;
            }
        }
    }

    public void SetTarget<T>(T target) where T : MonoBehaviour
    {
        targetHealth = target.GetComponent<Health>();
        if(targetHealth == null)
        {
            Debug.LogError("Target does not have a Health component");
        }
    }

    public void SetTarget(GameObject target)
    {
        targetHealth = target.GetComponent<Health>();
        if(targetHealth == null)
        {
            Debug.LogError("Target does not have a Health component");
        }
    }
    void Attack()
    {
        targetHealth.HitDamage(attackDamage);
    }

    bool TargetInRange()
    {
        return Vector3.Distance(transform.position.xz(), targetHealth.transform.position.xz()) <= attackRange;
    }
}