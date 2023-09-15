using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// file SO chứa loại công trình ( tên , pref)
[CreateAssetMenu(menuName = "SO/buildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string nameBuilding;
    public Transform prefab;
    public ResourcesGeneratorData generatorData;
    public Sprite sprite;
    public Sprite ghorst;
}
