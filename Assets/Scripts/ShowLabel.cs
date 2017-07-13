using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLabel : MonoBehaviour
{
    [SerializeField] Transform label;
    [SerializeField] float speed = 3;
    Vector3 defaultScale;
    float scaleValue;
    HighLight highLight;
    // Use this for initialization
    void Start()
    {
        highLight = GetComponent<HighLight>();
        defaultScale = label.localScale;
        label.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (highLight.toLight)
        {
            scaleValue += Time.deltaTime * speed;
        }
        else
        {
            scaleValue -= Time.deltaTime * speed;
        }
        scaleValue = Mathf.Clamp(scaleValue, 0f, 1f);
        label.localScale = Mathf.Clamp(scaleValue, 0f, 1f) * defaultScale;
    }
}
