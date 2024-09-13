using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Resource Data", menuName = "Scriptables/Resource Data", order = 1)]
public class ResourceDataSO : ScriptableObject
{
    public string resName;
    public Sprite icon;
    public Inventory.ResourceType type;
}
