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

    [SerializeField] AudioClipSO startInteraction;
    [SerializeField] AudioClipSO interactionInProgress;
    [SerializeField] AudioClipSO endInteraction;

    AudioManager audioManager;

    private void Start()
    {
        player = GameManager.I.Player;
        if(progressCircleUI != null)
            progressCircleUI.gameObject.SetActive(false);
        
        resourceRequirementsUI = GetComponentInChildren<ResourceRequirementsUI>();

        resourceRequirementsUI?.UpdateVisual(interactable.I.GetRequirements());

        audioManager = gameObject.AddComponent<AudioManager>();
        audioManager.AddClip(startInteraction);
        audioManager.AddClip(interactionInProgress);
        audioManager.AddClip(endInteraction);

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
        audioManager.Play(startInteraction);
        audioManager.Play(interactionInProgress);
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
        audioManager.Play(endInteraction);
        rewards = interactable.I.GetInteractionReward();

        GameManager.I.Player.GetComponent<Inventory>().AddResources(rewards);
        interactable.I.Interact();
        isInteracting = false;
        interactTimer = 0;
        if(progressCircleUI != null)
        {
            progressCircleUI.SetProgress(0);
            progressCircleUI.gameObject.SetActive(false);
        }




        if(interactable.I.IsInteractable() == false)
        {
            audioManager.Stop(interactionInProgress);
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
                audioManager.Stop(interactionInProgress);
                player.InteractionFinished();
                resourceRequirementsUI?.gameObject.SetActive(true);
                if(player.hoveredInteractionHandler == this)
                    progressCircleUI.gameObject.SetActive(true);
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

    public void OnHoverStart()
    {
        progressCircleUI?.gameObject.SetActive(true);
    }

    public void OnHoverEnd()
    {
        if (isInteracting == false)
        {
            progressCircleUI?.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(interactable.I.IsInteractable() == false)
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
