using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum ResourceType
    {
        Wood,
        Stone,
    }

    List<int> resourceCount;

    private void Start()
    {
        resourceCount = new List<int>(new int[Enum.GetValues(typeof(ResourceType)).Length]);
    }


    public void AddResource(ResourceType type, int count)
    {
        resourceCount[(int)type] += count;
    }

    public void RemoveResource(ResourceType type, int count) 
    {
        if (resourceCount[(int)type] < count)
            throw new Exception("Not enough resources");

        resourceCount[(int)type] -= count;
    }

    public int GetResourceCount(ResourceType type)
    {
        return resourceCount[(int)type];
    }

    public bool HasResources(ItemCollection requirements)
    {
        foreach (var requirement in requirements.items)
        {
            if (resourceCount[(int)requirement.Key] < requirement.Value)
                return false;
        }

        return true;
    }

    public void RemoveResources(ItemCollection requirements)
    {
        foreach (var requirement in requirements.items)
        {
            RemoveResource(requirement.Key, requirement.Value);
        }
    }

    public void AddResources(ItemCollection requirements)
    {
        foreach (var requirement in requirements.items)
        {
            AddResource(requirement.Key, requirement.Value);
        }
    }
}
