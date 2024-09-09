using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;




    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    HashSet<InteractionHandler> interactionHandlers = new HashSet<InteractionHandler>();

    InteractionHandler currentInteractionHandler;

    public void AddInterationHandler(InteractionHandler handler)
    {
        interactionHandlers.Add(handler);
        currentInteractionHandler = interactionHandlers.First();
    }

    public void RemoveInteractionHandler(InteractionHandler handler)
    {
        interactionHandlers.Remove(handler);
        currentInteractionHandler = interactionHandlers.First();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
        if (currentInteractionHandler == null)
            return;
        currentInteractionHandler.StartInteraction();

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //This is called when you input a direction on a valid input type, such as arrow keys or analogue stick

        playerMovement.SetMovementDirection(context.ReadValue<Vector2>());
    }
}
