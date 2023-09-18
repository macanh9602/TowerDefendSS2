using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
{
    [SerializeField] RectTransform CanvasRectTransform;
    RectTransform rectTransform;
    RectTransform backgroundRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        backgroundRectTransform = rectTransform.Find("Image").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 anchorPosition = Input.mousePosition / CanvasRectTransform.localScale.x;
        if (anchorPosition.x + backgroundRectTransform.rect.width > CanvasRectTransform.rect.width)
        {
            anchorPosition.x = CanvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if (anchorPosition.y + backgroundRectTransform.rect.height > CanvasRectTransform.rect.height)
        {
            anchorPosition.y = CanvasRectTransform.rect.height - backgroundRectTransform.rect.height;
        }
        if (anchorPosition.x < 0)
        {
            anchorPosition.x = 0;
        }
        if (anchorPosition.y < 0)
        {
            anchorPosition.y = 0;
        }
        rectTransform.anchoredPosition = anchorPosition;
    }
}
