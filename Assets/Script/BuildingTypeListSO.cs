using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//file SO lưu list công trình
[CreateAssetMenu(menuName = "SO/BuildingTypeListSO")]
public class BuildingTypeListSO : ScriptableObject
{
    public List<BuildingTypeSO> lstBuildings;
}
