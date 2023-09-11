using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//file SO lưu list tài nguyên được sản xuất
[CreateAssetMenu(menuName = "SO/ResourcesTypeListSO")]
public class ResourcesTypeListSO : ScriptableObject
{
    public List<ResourcesTypeSO> lstResources;
}
