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
    [SerializeField] GameObject RequirementsUi;
    [SerializeField] ItemCollection requirements;
    [SerializeField]
    public Dictionary<Inventory.ResourceType, int> items;
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
        return requirements;
    }

    public bool IsInteractable()
    {
        return buildingSlot.activeSelf;
    }

    public void DestroyBuilding()
    {
        buildingConstructed.SetActive(false);
        buildingSlot.SetActive(true);
        RequirementsUi.SetActive(true);
    }
}
