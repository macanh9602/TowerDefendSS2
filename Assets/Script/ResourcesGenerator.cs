using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//resource generator : máy tạo tài nguyên
//tạo tài nguyên từ các building --> tạo logic từ các building (add to pref building)

public class ResourcesGenerator : MonoBehaviour
{
    private float time;
    private float timeMax;
    private int nearbyResourceAmount;
    private ResourcesGeneratorData resourcesGeneratorData;
    public static int GetNearByResourceAmount(ResourcesGeneratorData resourcesGeneratorData, Vector3 position)
    {
        int nearbyResourceAmount = 0;
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(position, resourcesGeneratorData.resourceDitectionRadius);
        foreach (Collider2D collider2D in collider2DArray)
        {
            ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if (resourceNode != null)
            {
                if (resourceNode.resourcesType == resourcesGeneratorData.resourcesType)
                {
                    nearbyResourceAmount++;
                }

            }

        }

        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, resourcesGeneratorData.maxResourceAmount);
        return nearbyResourceAmount;
    }

    private void Awake()
    {
        resourcesGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.generatorData;
        timeMax = resourcesGeneratorData.timeMax;
    }
    private void Start() //xét số lượng tài nguyên nằm trong bán kính đặt loại building (amount ++ )
    {
        nearbyResourceAmount = GetNearByResourceAmount(resourcesGeneratorData, transform.position);
        Debug.Log("Amount : " + nearbyResourceAmount);
        if (nearbyResourceAmount == 0)
        {
            enabled = false;
        }
        else
        {
            timeMax = timeMax / 2 + timeMax / nearbyResourceAmount;
        }
        //else chinh timemax ty le nghich voi nearby --> time smooth hon + dung cho bài toán khác
    }
    private void Update() // kinh tế : tăng số lượng loại tài nguyên thu thập được theo timeMax(được dịnh nghĩa trong Data)
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time += timeMax;
            Debug.Log("time : " + time + ";" + "Time max : " + timeMax);
            //Debug.Log("+ 1 " + buildingType.generatorData.resourcesType.name);

            ResourcesManager.instance.addResources(resourcesGeneratorData.resourcesType, nearbyResourceAmount);
        }
    }
    public ResourcesGeneratorData getResourcesGeneratorData()
    {
        return resourcesGeneratorData;
    }
    public float getResourceAmount()
    {
        return nearbyResourceAmount;
    }
    public float getTimeSpeedMakeResource()
    {
        return time / timeMax;
    }

}
