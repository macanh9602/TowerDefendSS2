using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuldingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private Transform btnTemplate;
    private float index = 0;
    private float offsetAmount = 150f;
    private BuildingTypeListSO buildingTypeList;
    //Dictionary<BuildingTypeSO, Transform> buildingTypeDictionary;
    private void Awake()
    {
        btnTemplate.gameObject.SetActive(false);
        //buildingTypeDictionary = new Dictionary<BuildingTypeSO, Transform>();
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        foreach (BuildingTypeSO buildingType in buildingTypeList.lstBuildings)
        {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            Image img = btnTransform.Find("Image").GetComponent<Image>();
            img.sprite = buildingType.sprite;
            btnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(offsetAmount * index, 0);
            index++;
            //BuildingTypeTransform = buildingTypeDictionary[buildingType];
            btnTransform.gameObject.SetActive(true);
            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.setActiveBuildingType(buildingType);
            });
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
