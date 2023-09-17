using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Data1Buidling : MonoBehaviour
{
    [SerializeField] ResourcesGenerator resourcesGenerator;
    // Start is called before the first frame update
    [SerializeField] Transform bar;
    [SerializeField] float xlocal;
    void Awake()
    {

    }
    private void Start()
    {
        ResourcesGeneratorData resourcesGeneratorData = resourcesGenerator.getResourcesGeneratorData();
        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite = resourcesGeneratorData.resourcesType.sprite;
        transform.Find("Text (TMP)").GetComponent<TMP_Text>().text = resourcesGenerator.getResourceAmount().ToString();
        bar = transform.Find("Bar");
        xlocal = bar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(resourcesGenerator.getTimeSpeedMakeResource() * xlocal, 1, 1);
    }
}
