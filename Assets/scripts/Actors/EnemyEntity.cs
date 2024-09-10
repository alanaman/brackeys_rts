using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    void Start()
    {
        GameManager.I.AddEnemyEntity(this);
    }

    private void OnDestroy()
    {
        GameManager.I.removeEnemyEntity(this);
    }
}
