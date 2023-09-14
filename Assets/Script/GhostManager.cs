using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostManager : MonoBehaviour
{
    private GameObject ghost;
    private BuildingTypeSO ActiveBuildingType;

    private void Awake()
    {
        ghost = GameObject.Find("Ghost");
    }
    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Z))
        //{
        //    Hide(); ;
        //}
        //if (Input.GetKeyUp(KeyCode.X))
        //{
        //    Show();
        //}
        BuildingManager.Instance.OnChangeBuildingType += BuidlingManager_OnChangeBuildingType;
        GhostFuction();

    }

    private void GhostFuction()
    {
        if (ActiveBuildingType != null)
        {
            Show(ActiveBuildingType);
            ghost.transform.position = Extensions.getMousePosition();
        }
        else
        {
            Hide();
        }
    }

    private void BuidlingManager_OnChangeBuildingType(object sender, EventArgs e)
    {
        ActiveBuildingType = BuildingManager.Instance.getActiveBuildingType();
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
