using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPointScript : MonoBehaviour
{
    //This scripts lets the user drag and drop the points of the first spline

    private Vector3 _dragOffset;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + _dragOffset;
    }

    //This function returns the position of the mouse as a Vector3 in WorldPoint with a Z-axis value of 0
    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
