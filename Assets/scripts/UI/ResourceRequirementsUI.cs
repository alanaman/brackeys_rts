using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRequirementsUI : MonoBehaviour
{
    [SerializeField] GameObject iconTemplate;

    [SerializeField] IRef<IInteractable> interactable;

    private void Awake()
    {
        iconTemplate.SetActive(false);
    }

    private void Start()
    {
        UpdateVisual(interactable.I.GetRequirements());
    }

    public void UpdateVisual(ItemCollection itemCollection)
    {
        foreach(Transform child in transform)
        {
            if(child == iconTemplate.transform)
                continue;
            Destroy(child.gameObject);
        }

        ItemCollection reqs = interactable.I.GetRequirements();
        foreach (var req in reqs.items)
        {
            if(req.Value <= 0)
                continue;
            ResourceDataSO data = EnumToSoMigarte.GetSo(req.Key);
            SingleResReqUI iconInst = Instantiate(iconTemplate, transform).GetComponent<SingleResReqUI>();
            iconInst.gameObject.SetActive(true);
            iconInst.SetResource(data, req.Value);
        }
    }
}
