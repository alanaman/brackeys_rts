
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnumToSoMigarte : MonoBehaviour
{
    [SerializeField] List<ResourceDataSO> resourceDataSOs;

    public static EnumToSoMigarte I { get; private set; }

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(this);
            return;
        }

        I = this;
    }

    public static ResourceDataSO GetSo(Inventory.ResourceType type)
    {
        for(int i = 0; i < I.resourceDataSOs.Count; i++)
        {
            if(I.resourceDataSOs[i].type == type)
            {
                return I.resourceDataSOs[i];
            }
        }
        return null;
    }
}