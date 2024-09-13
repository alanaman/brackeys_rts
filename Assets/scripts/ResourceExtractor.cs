using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceExtractor : MonoBehaviour, IInteractable
{
    public int nInteractionsRequired = 3;
    int currentInteractions = 0;

    public int rewardAmt = 3;
    public Inventory.ResourceType resourceType;

    [SerializeField] GameObject availableResourceViz;
    [SerializeField] GameObject depleatedResourceViz;
    [SerializeField] Collider resourceCollectionCollider;

    bool isInteractable = true;

    HealthBarUI healthBarUI;

    private void Start()
    {
        depleatedResourceViz.SetActive(false);
        availableResourceViz.SetActive(true);

        healthBarUI = GetComponentInChildren<HealthBarUI>();
        healthBarUI.SetMaxHealth(nInteractionsRequired);
    }

    public void GetExtractedResource()
    {
        currentInteractions++;

        healthBarUI.SetHealth(nInteractionsRequired - currentInteractions);

        if (currentInteractions >= nInteractionsRequired)
        {
            ConvertToDepletedResource();
        }
    }

    void ConvertToDepletedResource()
    {
        availableResourceViz.SetActive(false);
        depleatedResourceViz.SetActive(true);
        resourceCollectionCollider.enabled = false;
        healthBarUI.gameObject.SetActive(false);
        isInteractable = false;
    }


    public void Interact()
    {
        GetExtractedResource();
    }

    public virtual ItemCollection GetInteractionReward()
    {
        ItemCollection rewards = new ItemCollection();
        rewards.items.Add(resourceType, rewardAmt);
        return rewards;
    }

    public bool IsInteractable()
    {
        return isInteractable;
    }
}
