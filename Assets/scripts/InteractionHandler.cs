using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public IRef<IInteractable> interactable;

    public bool instant;
    public bool autoContinue;
    public float timeToInteract;
    

    float interactTimer;
    bool isInteracting;

    ItemCollection rewards;

    static Player player;

    [SerializeField] ProgressCircleUI progressCircleUI;
    ResourceRequirementsUI resourceRequirementsUI;



    private void Start()
    {
        player = GameManager.I.Player;
        if(progressCircleUI != null)
            progressCircleUI.gameObject.SetActive(false);
        
        resourceRequirementsUI = GetComponentInChildren<ResourceRequirementsUI>();

        resourceRequirementsUI?.UpdateVisual(interactable.I.GetRequirements());
    }

    private void Update()
    {
        if(isInteracting)
        {
            interactTimer += Time.deltaTime;
            progressCircleUI.SetProgress(interactTimer / timeToInteract);
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
            if(progressCircleUI != null)
                progressCircleUI.gameObject.SetActive(true);
        }
        resourceRequirementsUI?.gameObject.SetActive(false);
    }

    void FinishInteraction()
    {
        rewards = interactable.I.GetInteractionReward();

        GameManager.I.Player.GetComponent<Inventory>().AddResources(rewards);
        interactable.I.Interact();
        isInteracting = false;
        interactTimer = 0;
        if(progressCircleUI != null)
            progressCircleUI.gameObject.SetActive(false);




        if(interactable.I.IsInteractiable() == false)
        {
            player.InteractionFinished();
            player.RemoveInteractionHandler(this);
        }
        else
        {
            if (autoContinue)
            {
                TryStartInteraction();
            }
            else
            {
                player.InteractionFinished();
                resourceRequirementsUI?.gameObject.SetActive(true);
                progressCircleUI.gameObject.SetActive(false);
            }

        }

        //TODO: destroy interactable stuff if no longer needed
    }

    public void CancelInteraction()
    {
        isInteracting = false;

        //let progress be saved
        //interactTimer = 0;
    }

    public bool TryStartInteraction()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if(inventory.HasResources(interactable.I.GetRequirements()))
        {
            inventory.RemoveResources(interactable.I.GetRequirements());
            StartInteraction();
            return true;
        }
        else
        {
            IndicateRequirementsinsufficient();
            return false;
        }
    }

    void IndicateRequirementsinsufficient()
    {
        Debug.Log("Requirements insufficient");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(interactable.I.IsInteractiable() == false)
        {
            return;
        }

        if (other == GameManager.I.PlayerCollider)
        {
            player.AddInterationHandler(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == GameManager.I.PlayerCollider)
        {
            player.RemoveInteractionHandler(this);
        }
    }

    private void OnDestroy()
    {
        player.RemoveInteractionHandler(this);
    }

    private void OnDisable()
    {
        player.RemoveInteractionHandler(this);
    }
}
