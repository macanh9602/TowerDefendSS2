using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private Transform resourcesTemplate;
    private ResourcesTypeListSO resourcesTypeList;
    Dictionary<ResourcesTypeSO, Transform> resourceTypeTransformDictionary;
    private float index = 0;
    private float offsetAmount = -250f;
    private void Awake()
    {
        resourcesTemplate.gameObject.SetActive(false);
        resourceTypeTransformDictionary = new Dictionary<ResourcesTypeSO, Transform>();
        resourcesTypeList = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
        foreach (ResourcesTypeSO resourceType in resourcesTypeList.lstResources)
        {
            Transform resourceTransform = Instantiate(resourcesTemplate, transform);
            Image img = resourceTransform.GetComponentInChildren<Image>();
            resourceTransform.gameObject.SetActive(true);
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(index * offsetAmount, 0);
            index++;
            resourceTypeTransformDictionary[resourceType] = resourceTransform;
            img.sprite = resourceType.sprite;
            //Debug.Log(text.text);
        }
    }
    private void Start()
    {
        ResourcesManager.instance.OnResourceAmountChange += ResourcesManager_IncreaseResourceAmount;
        UpdateResourceAmount();
    }

    private void ResourcesManager_IncreaseResourceAmount(object sender, EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {

        resourcesTypeList = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
        foreach (ResourcesTypeSO resourceType in resourcesTypeList.lstResources)
        {
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];
            TMP_Text text = resourceTransform.GetComponentInChildren<TMP_Text>();
            string number = ResourcesManager.instance.GetResourceAmount(resourceType).ToString();
            text.text = number;
        }
    }

}
