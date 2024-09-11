using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IInteractable
{

    [SerializeField]
    GameObject buildingConstructed;
    [SerializeField]
    GameObject buildingSlot;

    [SerializeField] bool isPreconstructed;

    private void Start()
    {
        if(isPreconstructed)
        {
            buildingConstructed.SetActive(true);
            buildingSlot.SetActive(false);
        }
        else
        {
            buildingConstructed.SetActive(false);
            buildingSlot.SetActive(true);
        }
    }

    public void Interact()
    {
        buildingConstructed.SetActive(true);
        buildingSlot.SetActive(false);
    }

    public virtual ItemCollection GetRequirements()
    {
        ItemCollection req = new ItemCollection();
        req.items.Add(Inventory.ResourceType.Wood, 2);
        return req;
    }

    public bool IsInteractiable()
    {
        return buildingSlot.activeSelf;
    }

    public void DestroyBuilding()
    {
        buildingConstructed.SetActive(false);
        buildingSlot.SetActive(true);
    }
}
