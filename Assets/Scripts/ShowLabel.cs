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
    bool islabel;
    Camera _camera;
    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
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
        //设置label
        for (int i = 0; i < labels.Length; i++)
        {
            if (labels.Length < 2)
            {
                labels[i].position = highLight.ShowLabelPos;
            }

            labels[i].parent = transform;
            labels[i].LookAt(_camera.transform.position);
            labels[i].Rotate(new Vector3(-90, 0, 180), Space.Self);
            labels[i].localScale = Mathf.Clamp(scaleValue, 0f, 1f) * defaultScales[i];
        }
    }
}
