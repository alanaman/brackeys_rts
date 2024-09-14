using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryUI : MonoBehaviour
{
    [SerializeField] Button restartButton;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        restartButton.onClick.AddListener(() =>
        {

        });
    }
}
