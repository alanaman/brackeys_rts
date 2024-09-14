using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button continueButton;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        restartButton.onClick.AddListener(() =>
        {

        });

        continueButton.onClick.AddListener(() =>
        {
            GameManager.I.OnContinue();
        });

    }
} 
