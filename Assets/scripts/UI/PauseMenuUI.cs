using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneManager.GetActiveScene().name);
        });

        continueButton.onClick.AddListener(() =>
        {
            GameManager.I.OnContinue();
        });

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

    }
} 
