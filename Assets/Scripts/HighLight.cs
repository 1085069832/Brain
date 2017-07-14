using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{

    [SerializeField] Material defaultMat;
    [SerializeField] Material lightMat;
    [HideInInspector] public bool toLight;
    Renderer[] renders;
    Vector3 showLabelPos;

    /// <summary>
    /// label显示的位置
    /// </summary>
    public Vector3 ShowLabelPos
    {
        get
        {
            return showLabelPos;
        }

        set
        {
            showLabelPos = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        renders = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toLight)
        {
            foreach (Renderer render in renders)
            {
                render.material = lightMat;
            }
        }
        else
        {
            foreach (Renderer render in renders)
            {
                render.material = defaultMat;
            }
        }
    }
}
