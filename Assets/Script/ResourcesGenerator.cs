using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//resource generator : máy tạo tài nguyên
//tạo tài nguyên từ các building --> tạo logic từ các building (add to pref building)
public class ResourcesGenerator : MonoBehaviour
{

    private float time;
    private BuildingTypeSO buildingType;
    private void Start()
    {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time += buildingType.generatorData.timeMax;
            //Debug.Log("+ 1 " + buildingType.generatorData.resourcesType.name);
            ResourcesManager.instance.addResources(buildingType.generatorData.resourcesType, 1);
        }
    }
}
