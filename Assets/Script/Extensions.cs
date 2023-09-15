using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extensions
{
    private static Camera mainCamera;
    public static Vector2 getMousePosition()
    {
        Vector3 mouseWordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWordPosition.z = 0;
        return mouseWordPosition;
    }

}
