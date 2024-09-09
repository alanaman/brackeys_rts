using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public IRef<IInteractable> interactable;

    public bool instant;
    public float timeToInteract;
    

    float interactTimer;
    bool isInteracting;

    ItemCollection rewards;

    private void Update()
    {
        if(isInteracting)
        {
            interactTimer += Time.deltaTime;
            if(interactTimer >= timeToInteract)
            {
                FinishInteraction();
            }
        }
    }

    public float Getinteractionprogress()
    {
        return interactTimer / timeToInteract;
    }

    void StartInteraction()
    {
        if(instant)
        {
            FinishInteraction();
        }
        else
        {
            isInteracting = true;
        }
    }

    void FinishInteraction()
    {
        rewards = interactable.I.GetInteractionReward();
        GameManager.I.Player.GetComponent<Inventory>().AddResources(rewards);
        interactable.I.Interact();
        isInteracting = false;
        interactTimer = 0;

        //TODO: destroy interactable stuff if no longer needed
    }

    public void CancelInteraction()
    {
        isInteracting = false;

        //let progress be saved
        //interactTimer = 0;
    }

    public void TryStartInteraction()
    {
        Inventory inventory = GameManager.I.Player.GetComponent<Inventory>();
        if(inventory.HasResources(interactable.I.GetRequirements()))
        {
            inventory.RemoveResources(interactable.I.GetRequirements());
            StartInteraction();
        }
        else
        {
            IndicateRequirementsinsufficient();
        }
    }

    void IndicateRequirementsinsufficient()
    {
        Debug.Log("Requirements insufficient");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == GameManager.I.PlayerCollider)
        {
            Debug.Log("collision");
            GameManager.I.Player.AddInterationHandler(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == GameManager.I.PlayerCollider)
        {
            GameManager.I.Player.RemoveInteractionHandler(this);
        }
    }
}
