using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleResReqUI : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI countText;

    public void SetResource(ResourceDataSO data, int count)
    {
        image.sprite = data.icon;
        countText.text = count.ToString();
    }
}
