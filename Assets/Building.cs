using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IInteractable
{

    [SerializeField]
    GameObject buildingConstructed;
    [SerializeField]
    GameObject buildingSlot;

    private void Start()
    {
        buildingConstructed.SetActive(false);    
    }

    public void Interact()
    {
        Debug.Log("Building Interacted");
        buildingConstructed.SetActive(true);
        buildingSlot.SetActive(false);
    }

    public virtual ItemCollection GetRequirements()
    {
        ItemCollection req = new ItemCollection();
        req.items.Add(Inventory.ResourceType.Wood, 2);
        return req;
    }
}
