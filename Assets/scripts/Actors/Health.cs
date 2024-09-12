using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10;
    float currentHealth;
    public HealthBarUI healthBar;
    [SerializeField] bool destroyOnZeroHP = true;


    [SerializeField] UnityEvent OnZeroHP; 


    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void HitDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            OnZeroHP.Invoke();
            if(destroyOnZeroHP)
                Destroy(gameObject);
        }
    }

    public float GetHealth() { return maxHealth; }

    private void OnEnable()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }
}
