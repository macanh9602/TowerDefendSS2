using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.EventSystems;
//script gắn GObj trong main 
// file quản lý tài nguyên ( chuyển danh sách tài nguyên từ list vào trong thư viện dưới dạng key-value )
// có hàm addResource --> + giá trị vào key (value ban đầu = 0)
//có sự kiện "số lượng thu hoạch tăng"
//có hàm lấy ra số lượng thu hoạch của loại tài nguyên (key -> value )
public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance { get; private set; }
    Dictionary<ResourcesTypeSO, int> m_Resources;
    public event EventHandler OnResourceAmountChange;
    // Start is called before the first frame update

    void Awake()
    {
        //sad
        instance = this;
        m_Resources = new Dictionary<ResourcesTypeSO, int>();
        ResourcesTypeListSO resourcesTypeList = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
        //Debug.Log(Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name));
        foreach (ResourcesTypeSO resourceType in resourcesTypeList.lstResources) // cai value vao tat ca cac key
        {
            m_Resources[resourceType] = 0;
        }
        //testLog();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    ResourcesTypeListSO resourcesTypeList = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
        //    addResources(resourcesTypeList.lstResources[0], 2);
        //    //testLog();
        //}

    }

    void testLog()
    {
        foreach (ResourcesTypeSO resourceType in m_Resources.Keys)
        {
            Debug.Log(resourceType.nameResource + ":" + m_Resources[resourceType]);
        }
    }
    public void addResources(ResourcesTypeSO resourcesType, int value)
    {
        m_Resources[resourcesType] += value;
        OnResourceAmountChange?.Invoke(this, EventArgs.Empty);
        //testLog();
    }
    public int GetResourceAmount(ResourcesTypeSO resourcesType)
    {
        return m_Resources[resourcesType];
    }

    public bool CanBuild(BuildingCost[] buildingCostsArray)
    {
        foreach (BuildingCost cost in buildingCostsArray)
        {
            if (GetResourceAmount(cost.resourcesType) >= cost.amount)
            {
                //
            }
            else
            {
                //
                return false;
            }
        }
        return true;
    }
    public void UseMoney(BuildingCost[] buildingCostsArray)
    {
        foreach (BuildingCost cost in buildingCostsArray)
        {
            m_Resources[cost.resourcesType] -= cost.amount;

        }
    }

}
