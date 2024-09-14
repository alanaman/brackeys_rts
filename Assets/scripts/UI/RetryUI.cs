
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryUI : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneManager.GetActiveScene().name);
        });
        exitButton.onClick.AddListener(() => { Application.Quit(); });
    }
}
