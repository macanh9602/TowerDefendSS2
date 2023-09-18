using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// gán vào "pfResourceGeneratorOverlayGhost" trong BuildingGhost
//cx tạo ra Hide / Show
//trả về Icon , % percent 
public class OverlayGhost : MonoBehaviour
{
    [SerializeField] ResourcesGeneratorData resourcesGeneratorData;
    //public void static 
    private void Awake()
    {
        //Hide();
    }
    private void Update()
    {
        int nearbyResourceAmount = ResourcesGenerator.GetNearByResourceAmount(resourcesGeneratorData, transform.position);
        float percent = Mathf.RoundToInt((float)nearbyResourceAmount / resourcesGeneratorData.maxResourceAmount * 100f);
        transform.Find("Text (TMP)").GetComponent<TMP_Text>().text = percent.ToString() + "%";
    }
    public void Show(ResourcesGeneratorData resourcesGeneratorData)
    {
        this.resourcesGeneratorData = resourcesGeneratorData;
        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite = resourcesGeneratorData.resourcesType.sprite;

        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
