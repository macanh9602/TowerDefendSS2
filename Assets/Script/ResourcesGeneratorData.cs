using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class định nghĩa thông tin dữ liệu : thời gian sinh tài nguyên , loại tài nguyên , bán kính tài nguyên , số lượng tài nguyên tối đa được khai thác 
[System.Serializable]
public class ResourcesGeneratorData
{
    public float timeMax;
    public ResourcesTypeSO resourcesType;
    public float resourceDitectionRadius;
    public int maxResourceAmount;
}
