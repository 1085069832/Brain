using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrainTransparent : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] float startValue = 1f;
    BrainController brainController;

    private void Start()
    {
        brainController = GetComponent<BrainController>();
        mat.DOFade(brainController.DisScale, 0);
    }

    public void ChangeMatColor(float value)
    {
        mat.DOFade(brainController.DisScale, 0);
    }
}
