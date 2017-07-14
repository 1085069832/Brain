using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    HighLight highLight;
    ShowLabel showLabel;
    Camera _camera;
    RaycastHit raycastHit;
    bool isEnter;

    private void OnMouseEnter()
    {
        _camera = Camera.main;
        isEnter = true;
        highLight = GetComponentInParent<HighLight>();
        showLabel = GetComponentInParent<ShowLabel>();
        highLight.ToLight();
    }

    private void Update()
    {
        if (isEnter && !showLabel.isShowAll)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                bool isCollider = Physics.Raycast(ray, out raycastHit, 10);

                if (isCollider)
                {
                    showLabel.showlabel = true;
                    showLabel.ShowLabelPos = raycastHit.point;
                    showLabel.InitLabel();
                }
            }
        }
    }

    private void OnMouseExit()
    {
        isEnter = false;
        showLabel.showlabel = false;
        highLight.ToDefault();
    }
}
