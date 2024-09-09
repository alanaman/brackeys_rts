using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutter : MonoBehaviour, IInteractable
{
    public int requiredChops = 3;
    int currentChops = 0;

    public int woodRewardAmt = 3;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject stub;
    [SerializeField] Collider chopCollider;

    private void Start()
    {
        stub.SetActive(false);
        tree.SetActive(true);
    }

    public void Chop()
    {
        Debug.Log("Chop");
        currentChops++;

        if (currentChops >= requiredChops)
        {
            ConvertToStub();
        }
    }

    void ConvertToStub()
    {
        tree.SetActive(false);
        stub.SetActive(true);
        chopCollider.gameObject.SetActive(false);
    }

    public void Interact()
    {
        Chop();
    }


}
