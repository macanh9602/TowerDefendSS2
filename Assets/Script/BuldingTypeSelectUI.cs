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
    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;

    [SerializeField] Sprite mouseSprite;
    private Transform btnMouse;

    [SerializeField] List<BuildingTypeSO> ignorBuildingType;
    //Dictionary<BuildingTypeSO, Transform> buildingTypeDictionary;
    private void Awake()
    {

        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();
        btnTemplate.gameObject.SetActive(false);
        btnMouse = Instantiate(btnTemplate, transform);
        btnMouse.Find("Image").GetComponent<Image>().sprite = mouseSprite;
        btnMouse.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        btnMouse.GetComponent<RectTransform>().anchoredPosition += new Vector2(offsetAmount * index, 0);
        index++;
        btnMouse.gameObject.SetActive(true);
        btnMouse.GetComponent<Button>().onClick.AddListener(() =>
        {
            BuildingManager.Instance.setActiveBuildingType(null);
            btnMouse.Find("Select").gameObject.SetActive(true);

        });
        index = 1;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        foreach (BuildingTypeSO buildingType in buildingTypeList.lstBuildings)
        {
            if (ignorBuildingType.Contains(buildingType)) continue;
            Transform btnTransform = Instantiate(btnTemplate, transform);
            Image img = btnTransform.Find("Image").GetComponent<Image>();
            img.sprite = buildingType.sprite;
            btnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(offsetAmount * index, 0);
            index++;
            btnTransformDictionary[buildingType] = btnTransform;
            btnTransform.gameObject.SetActive(true);
            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.setActiveBuildingType(buildingType);
                btnMouse.Find("Select").gameObject.SetActive(false);
            });
        }
    }
    private void Start()
    {
        BuildingManager.Instance.OnChangeBuildingType += BuildingManager_OnChangeBuildingType;
        UpdateActiveBuidlingTypeButton();
    }

    private void BuildingManager_OnChangeBuildingType(object sender, BuildingManager.OnActiveBuidlingChangeEventArg e)
    {
        UpdateActiveBuidlingTypeButton();
    }

    // Start is called before the first frame update
    void Update()
    {

    }
    void UpdateActiveBuidlingTypeButton()
    {
        foreach (BuildingTypeSO buildingType in btnTransformDictionary.Keys)
        {
            Transform btnTransform = btnTransformDictionary[buildingType];
            btnTransform.Find("Select").gameObject.SetActive(false);

        }
        BuildingTypeSO ActivebuildingType = BuildingManager.Instance.getActiveBuildingType();
        if (ActivebuildingType != null)
        {
            btnTransformDictionary[ActivebuildingType].Find("Select").gameObject.SetActive(true);
        }

    }
    //void GhostFromActiveBuidlingType()
    //{
    //    BuildingTypeSO ActivebuildingType = BuildingManager.Instance.getActiveBuildingType();
    //    ActivebuildingType.prefab.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
    //    ActivebuildingType.prefab.GetComponent<SpriteRenderer>().sprite = ActivebuildingType.ghorst;
    //}
}
