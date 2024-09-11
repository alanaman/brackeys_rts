using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCircleUI : MonoBehaviour
{
    [SerializeField] Image progressImage;


    // Update is called once per frame
    public void SetProgress(float progress)
    {
        progressImage.fillAmount = progress;
    }
}
