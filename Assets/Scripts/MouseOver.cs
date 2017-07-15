using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    HighLight highLight;
    ShowLabel showLabel;
    Camera _camera;
    RaycastHit raycastHit;
    [HideInInspector] public bool isEnter;
    [HideInInspector] public bool isSelect;

    private void Start()
    {
        _camera = Camera.main;
        highLight = GetComponentInParent<HighLight>();
        showLabel = GetComponentInParent<ShowLabel>();
    }

    private void OnMouseEnter()
    {
        SetEnter(true);
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
                    SetSelect(true);
                }
            }
        }
        //点击其他地方
        if (!isEnter && isSelect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetSelect(false);
                showLabel.showlabel = false;
                highLight.ToDefault();
            }
        }
    }

    private void OnMouseExit()
    {
        SetEnter(false);
        if (!isSelect || showLabel.isShowAll)
            highLight.ToDefault();
    }
    /// <summary>
    /// 设置isSelect
    /// </summary>
    /// <param name="isSelect"></param>
    public void SetSelect(bool isSelect)
    {
        MouseOver[] mouseOvers = showLabel.GetComponentsInChildren<MouseOver>();
        foreach (MouseOver mouseOver in mouseOvers)
        {
            mouseOver.isSelect = isSelect;
        }
    }
    /// <summary>
    /// 设置isEnter
    /// </summary>
    /// <param name="isEnter"></param>
    public void SetEnter(bool isEnter)
    {
        MouseOver[] mouseOvers = showLabel.GetComponentsInChildren<MouseOver>();
        foreach (MouseOver mouseOver in mouseOvers)
        {
            mouseOver.isEnter = isEnter;
        }
    }
}
