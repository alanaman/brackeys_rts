using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class AllyEntity : MonoBehaviour
{
    Health health;

    void Start()
    {
        health = GetComponent<Health>();
        GameManager.I.AddAllyEntity(this);
    }

    private void OnDestroy()
    {
        GameManager.I.removeAllyEntity(this);
    }
}
