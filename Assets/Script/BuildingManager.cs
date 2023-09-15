using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
//tạo nhà máy , mỏ trên map 
public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    private BuildingTypeSO ActiveBuildingType;
    private BuildingTypeListSO buildingTypeList;

    public event EventHandler<OnActiveBuidlingChangeEventArg> OnChangeBuildingType;
    public class OnActiveBuidlingChangeEventArg : EventArgs
    {
        public BuildingTypeSO activeBuildingType;
    }


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
            if (ActiveBuildingType != null && CanSpawnBuiding(ActiveBuildingType, Extensions.getMousePosition()))
            {
                Instantiate(ActiveBuildingType.prefab, Extensions.getMousePosition(), Quaternion.identity);

            }


        }
    }
    public void setActiveBuildingType(BuildingTypeSO buildingType)
    {
        ActiveBuildingType = buildingType;
        OnChangeBuildingType?.Invoke(this, new OnActiveBuidlingChangeEventArg { activeBuildingType = ActiveBuildingType });
    }
    public BuildingTypeSO getActiveBuildingType()
    {
        return ActiveBuildingType;
    }
    public bool CanSpawnBuiding(BuildingTypeSO buildingType, Vector3 position)
    {
        BoxCollider2D boxCollider2D = buildingType.prefab.GetComponent<BoxCollider2D>();
        Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0);
        //Collider2D[] circleCollider2DArray = Physics2D.OverlapCircleAll(position, buildingType.minContructDistance);
        bool isAreaClear = collider2DArray.Length == 0;
        if (!isAreaClear) return false;

        collider2DArray = Physics2D.OverlapCircleAll(position, buildingType.minContructDistance);

        foreach (Collider2D collider in collider2DArray)
        {
            BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
            if (buildingTypeHolder != null)
            {
                if (buildingTypeHolder.buildingType == buildingType)
                {
                    return false;
                }
            }
        }

        float maxConstructionRadius = 50;
        collider2DArray = Physics2D.OverlapCircleAll(position, maxConstructionRadius);

        foreach (Collider2D collider in collider2DArray)
        {
            BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
            if (buildingTypeHolder != null)
            {
                return true;
            }
        }
        return false;
    }

}
