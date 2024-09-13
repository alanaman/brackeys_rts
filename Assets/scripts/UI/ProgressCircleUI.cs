using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCircleUI : MonoBehaviour
{
    [SerializeField] Image progressImage;

    private void Start()
    {
        progressImage.fillAmount = 0;
    }


    // Update is called once per frame
    public void SetProgress(float progress)
    {
        progressImage.fillAmount = progress;
    }
}
