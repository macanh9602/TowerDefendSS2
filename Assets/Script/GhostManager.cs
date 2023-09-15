using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostManager : MonoBehaviour
{
    private GameObject ghost;
    private void Awake()
    {
        ghost = GameObject.Find("Ghost");
    }
    private void Start()
    {
        BuildingManager.Instance.OnChangeBuildingType += BuidlingManager_OnChangeBuildingType;
    }
    private void Update()
    {
        ghost.transform.position = Extensions.getMousePosition();
    }
    private void BuidlingManager_OnChangeBuildingType(object sender, BuildingManager.OnActiveBuidlingChangeEventArg e)
    {
        e.activeBuildingType = BuildingManager.Instance.getActiveBuildingType();
        if (e.activeBuildingType != null)
        {
            Show(e.activeBuildingType);

        }
        else
        {
            Hide();
        }
    }
    private void Hide()
    {

        ghost.SetActive(false);
    }
    private void Show(BuildingTypeSO building)
    {
        ghost.GetComponent<SpriteRenderer>().sprite = building.sprite;
        ghost.SetActive(true);
    }
}
