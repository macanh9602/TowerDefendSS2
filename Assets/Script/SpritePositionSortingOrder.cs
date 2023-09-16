using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] bool runOnce;
    [SerializeField] float positionOffset;
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
    private void LateUpdate()
    {
        float precisionMultiplier = 5f; //giam tinh trang float(0.9 , 1.2) chuyen ve 1
        sprite.sortingOrder = (int)(-(transform.position.y + positionOffset) * precisionMultiplier);
        //Debug.Log(transform.position.y);
        if (runOnce)
        {
            Destroy(this);
        }
    }

}
