using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{

    [SerializeField] Material defaultMat;
    [SerializeField] Material lightMat;
    [HideInInspector] public bool toLight;
    Renderer[] renders;
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
