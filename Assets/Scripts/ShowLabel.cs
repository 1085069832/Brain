using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLabel : MonoBehaviour
{
    [SerializeField] Transform[] labels;
    [SerializeField] float speed = 3;
    List<Vector3> defaultScales = new List<Vector3>();
    float scaleValue;
    HighLight highLight;
    // Use this for initialization
    void Start()
    {
        highLight = GetComponent<HighLight>();
        foreach (Transform label in labels)
        {
            defaultScales.Add(label.localScale);
            label.localScale = Vector3.zero;
        }
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
        for (int i = 0; i < defaultScales.Count; i++)
        {
            labels[i].localScale = Mathf.Clamp(scaleValue, 0f, 1f) * defaultScales[i];
        }
    }
}
