using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;
    AnimationController animationController;

    Inventory inventory;

    bool isInteracting = false;
    InteractionHandler currentInteractionHandler;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        inventory = GetComponent<Inventory>();
        animationController = GetComponentInChildren<AnimationController>();
    }

    private void Update()
    {
        if (isInteracting)
        {
            if (!interactionHandlers.Contains(currentInteractionHandler))
            {
                CancelInteraction();
            }
        }
        else
        {
            hoveredInteractionHandler = GetNearestIH();
        }
    }

    InteractionHandler GetNearestIH()
    {
        InteractionHandler result = null;
        float shortestDistance = Mathf.Infinity;
        foreach (var ih in interactionHandlers)
        {
            if (Vector3.Distance(ih.transform.position, transform.position) < shortestDistance)
            {
                result = ih;
                shortestDistance = Vector3.Distance(ih.transform.position, transform.position);
            }
        }
        return result;
    }

    HashSet<InteractionHandler> interactionHandlers = new HashSet<InteractionHandler>();

    InteractionHandler hoveredInteractionHandler;

    public void AddInterationHandler(InteractionHandler handler)
    {
        interactionHandlers.Add(handler);
    }

    public void RemoveInteractionHandler(InteractionHandler handler)
    {
        interactionHandlers.Remove(handler);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
        if (hoveredInteractionHandler == null)
            return;
        if(hoveredInteractionHandler.TryStartInteraction())
        {
            isInteracting = true;
            currentInteractionHandler = hoveredInteractionHandler;
        }
    }

    void CancelInteraction()
    {
        isInteracting = false;
        currentInteractionHandler.CancelInteraction();
    }

    public void InteractionFinished()
    {
        isInteracting = false;
        currentInteractionHandler = null;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //This is called when you input a direction on a valid input type, such as arrow keys or analogue stick

        playerMovement.SetMovementDirection(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        animationController.OnAttack();
    }
}
