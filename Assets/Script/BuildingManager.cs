using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//tạo nhà máy , mỏ trên map 
public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    private BuildingTypeSO ActiveBuildingType;
    private BuildingTypeListSO buildingTypeList;

    public event EventHandler OnChangeBuildingType;

    private void Awake()
    {
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        //ActiveBuildingType = buildingTypeList.lstBuildings[0];
    }
    // Start is called before the first frame update
    void Start()
    {
        //afasaskdjmaklsfja
    }

    // Update is called once per frame
    void Update()
    {
        getMousePositionClick();
    }

    private void getMousePositionClick()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (ActiveBuildingType != null)
            {
                Instantiate(ActiveBuildingType.prefab, Extensions.getMousePosition(), Quaternion.identity);

            }
        }
    }
    //private Vector2 getMousePosition()
    //{
    //    Vector3 mouseWordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mouseWordPosition.z = 0;
    //    return mouseWordPosition;
    //}
    public void setActiveBuildingType(BuildingTypeSO buildingType)
    {
        ActiveBuildingType = buildingType;
        OnChangeBuildingType?.Invoke(this, EventArgs.Empty);
    }
    public BuildingTypeSO getActiveBuildingType()
    {
        return ActiveBuildingType;
    }
}
