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

    private void Update()
    {
        if(isInteracting)
        {
            interactTimer += Time.deltaTime;
            if(interactTimer >= timeToInteract)
            {
                Interact();
                interactTimer = 0;
                isInteracting = false;
            }
        }
    }

    public void StartInteraction()
    {
        if(instant)
        {
            Interact();
        }
        else
        {
            isInteracting = true;
        }
    }

    public void StopInteraction()
    {
        isInteracting = false;
        //interactTimer = 0;
    }

    virtual public void Interact()
    {
        interactable.I.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == GameManager.I.PlayerCollider)
        {
            Debug.Log("collision");
            GameManager.I.Player.AddInterationHandler(this);
        }
    }
}
