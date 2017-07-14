using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    HighLight highLight;
    Camera _camera;
    RaycastHit raycastHit;
    bool isEnter;

    private void OnMouseEnter()
    {
        _camera = Camera.main;
        isEnter = true;
        highLight = GetComponentInParent<HighLight>();
        highLight.toLight = true;
    }

    private void Update()
    {
        if (isEnter)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            bool isCollider = Physics.Raycast(ray, out raycastHit, 10);

            if (isCollider)
            {
                highLight.ShowLabelPos = raycastHit.point;
            }
        }
    }

    private void OnMouseExit()
    {
        isEnter = false;
        highLight.toLight = false;
    }
}
