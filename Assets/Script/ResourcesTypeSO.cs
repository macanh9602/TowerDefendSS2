using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//file SO lưu tài nguyên được sản xuất ( tên )
[CreateAssetMenu(menuName = "SO/ResourcesTypeSO")]
public class ResourcesTypeSO : ScriptableObject
{
    public string nameResource;
    public Sprite sprite;
}
