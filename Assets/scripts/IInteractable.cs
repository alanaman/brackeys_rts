using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();

    public virtual ItemCollection GetRequirements()
    {
        return new ItemCollection();
    }

    public virtual ItemCollection GetInteractionReward()
    {
        return new ItemCollection();
    }

    public bool IsInteractable();

}


