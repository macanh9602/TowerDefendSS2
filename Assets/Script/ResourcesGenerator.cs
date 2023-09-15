using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//resource generator : máy tạo tài nguyên
//tạo tài nguyên từ các building --> tạo logic từ các building (add to pref building)
public class ResourcesGenerator : MonoBehaviour
{

    private float time;
    private float timeMax;
    int nearbyResourceAmount;
    private ResourcesGeneratorData resourcesGeneratorData;
    private void Awake()
    {
        resourcesGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.generatorData;
        timeMax = resourcesGeneratorData.timeMax;
    }
    private void Start()
    {
        nearbyResourceAmount = 0;
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, resourcesGeneratorData.resourceDitectionRadius);
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
        Debug.Log("Amount : " + nearbyResourceAmount);
        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, resourcesGeneratorData.maxResourceAmount);
        if (nearbyResourceAmount == 0)
        {
            enabled = false;
        }
        //else chinh timemax ty le nghich voi nearby --> time smooth hon
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time += timeMax;
            //Debug.Log("+ 1 " + buildingType.generatorData.resourcesType.name);

            ResourcesManager.instance.addResources(resourcesGeneratorData.resourcesType, nearbyResourceAmount);
        }
    }
}
