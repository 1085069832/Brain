﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIClick : MonoBehaviour
{
    [SerializeField] GameObject cerebriAnterior;
    [SerializeField] GameObject cerebriMedia;
    [SerializeField] GameObject cerebriPosterior;
    [SerializeField] GameObject cerebriCarotid;
    [SerializeField] GameObject cerebelliSuperior;
    [SerializeField] GameObject cerebelliInferior;
    [SerializeField] GameObject rightBrain;
    [SerializeField] GameObject LeftBrain;

    [SerializeField] Toggle cerebriAnteriorToggle;
    [SerializeField] Toggle cerebriMediaToggle;
    [SerializeField] Toggle cerebriPosteriorToggle;
    [SerializeField] Toggle cerebriCarotidToggle;
    [SerializeField] Toggle cerebelliSuperiorToggle;
    [SerializeField] Toggle cerebelliInferiorToggle;
    [SerializeField] Toggle showAllLabelToggle;
    [SerializeField] Toggle rightBrainToggle;
    [SerializeField] Toggle LeftBrainToggle;
    [SerializeField] GameObject[] blocks;
    bool isShowAll;

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnRightBrainIsShow()
    {
        if (rightBrainToggle.isOn)
        {
            rightBrain.SetActive(true);
        }
        else
        {
            rightBrain.SetActive(false);
        }
    }

    public void OnLeftBrainIsShow()
    {
        if (LeftBrainToggle.isOn)
        {
            LeftBrain.SetActive(true);
        }
        else
        {
            LeftBrain.SetActive(false);
        }
    }

    public void OnAllLabelShow()
    {
        if (showAllLabelToggle.isOn)
        {
            isShowAll = true;
        }
        else
        {
            isShowAll = false;
        }

        foreach (GameObject block in blocks)
        {
            ShowLabel[] showLabels = block.GetComponentsInChildren<ShowLabel>();
            foreach (ShowLabel label in showLabels)
            {
                label.isShowAll = isShowAll;
                MouseOver[] mouseOvers = label.GetComponentsInChildren<MouseOver>();
                foreach (MouseOver mouseOver in mouseOvers)
                {
                    mouseOver.isSelect = false;
                }
            }
        }
    }

    public void OnCerebriAnterior()
    {
        if (cerebriAnteriorToggle.isOn)
        {
            cerebriAnterior.SetActive(true);
        }
        else
        {
            cerebriAnterior.SetActive(false);
        }
    }

    public void OnCerebriMedia()
    {
        if (cerebriMediaToggle.isOn)
        {
            cerebriMedia.SetActive(true);
        }
        else
        {
            cerebriMedia.SetActive(false);
        }
    }

    public void OnCerebriPosterior()
    {
        if (cerebriPosteriorToggle.isOn)
        {
            cerebriPosterior.SetActive(true);
        }
        else
        {
            cerebriPosterior.SetActive(false);
        }
    }

    public void OnCerebriCarotid()
    {
        if (cerebriCarotidToggle.isOn)
        {
            cerebriCarotid.SetActive(true);
        }
        else
        {
            cerebriCarotid.SetActive(false);
        }
    }

    public void OnCerebelliSuperior()
    {
        if (cerebelliSuperiorToggle.isOn)
        {
            cerebelliSuperior.SetActive(true);
        }
        else
        {
            cerebelliSuperior.SetActive(false);
        }
    }

    public void OnCerebelliInferior()
    {
        if (cerebelliInferiorToggle.isOn)
        {
            cerebelliInferior.SetActive(true);
        }
        else
        {
            cerebelliInferior.SetActive(false);
        }
    }
}
