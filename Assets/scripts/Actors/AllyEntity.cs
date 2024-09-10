using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class AllyEntity : MonoBehaviour
{

    void Start()
    {
        GameManager.I.AddAllyEntity(this);
    }

    private void OnDestroy()
    {
        GameManager.I.removeAllyEntity(this);
    }
}
