using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager I { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject victoryMenu;

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(this);
            return;
        }

        I = this;
    }

    public void ShowPausemenu()
    {
        pauseMenu.SetActive(true);
    }

    public void HidePausemenu()
    {
        pauseMenu.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void HideGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }

    public void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }

    public void HideVictoryMenu()
    {
        victoryMenu.SetActive(false);
    }
}
