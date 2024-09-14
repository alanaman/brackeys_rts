using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public GameObject inventorybar;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;

    public void UpdateInventoryBar(Inventory.ResourceType type, int amt)
    {
        if (type == Inventory.ResourceType.Wood)
        {
            woodText.text = amt.ToString();
        }
        else if (type == Inventory.ResourceType.Stone)
        {
            stoneText.text = amt.ToString();
        }
    }

    public void ToggleInventoryBar()
    {
        if (inventorybar.activeInHierarchy)
        {
            inventorybar.SetActive(false);
        }
        else
        {
            inventorybar.SetActive(true);
        }
    }
}
