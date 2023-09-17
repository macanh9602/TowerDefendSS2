using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostManager : MonoBehaviour
{
    private GameObject ghost;
    //private GameObject ghostPercent;
    private OverlayGhost overlayGhost;
    private void Awake()
    {
        ghost = GameObject.Find("Ghost");
        overlayGhost = transform.Find("pfResourceGeneratorOverlayGhost").GetComponent<OverlayGhost>();
        Hide();
    }
    private void Start()
    {
        BuildingManager.Instance.OnChangeBuildingType += BuidlingManager_OnChangeBuildingType;
    }
    private void Update()
    {
        transform.position = Extensions.getMousePosition();
    }
    private void BuidlingManager_OnChangeBuildingType(object sender, BuildingManager.OnActiveBuidlingChangeEventArg e)
    {
        e.activeBuildingType = BuildingManager.Instance.getActiveBuildingType();
        if (e.activeBuildingType != null)
        {
            Show(e.activeBuildingType);
            overlayGhost.Show(e.activeBuildingType.generatorData);
        }
        else
        {
            Hide();
            overlayGhost.Hide();
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
