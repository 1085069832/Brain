using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    HighLight highLight;
    private void OnMouseEnter()
    {
        highLight = GetComponentInParent<HighLight>();
        highLight.toLight = true;
    }

    private void OnMouseExit()
    {
        highLight.toLight = false;
    }
}
