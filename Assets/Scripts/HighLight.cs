using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{

    [SerializeField] Material defaultMat;
    [SerializeField] Material lightMat;
    Renderer[] renders;

    // Use this for initialization
    void Start()
    {
        renders = GetComponentsInChildren<Renderer>();
    }
    /// <summary>
    /// 变亮
    /// </summary>
    public void ToLight()
    {
        foreach (Renderer render in renders)
        {
            if (render.tag != MyConst.LABEL)
                render.material = lightMat;
        }
    }
    /// <summary>
    /// 还原
    /// </summary>
    public void ToDefault()
    {
        foreach (Renderer render in renders)
        {
            if (render.tag != MyConst.LABEL)
                render.material = defaultMat;
        }
    }
}
