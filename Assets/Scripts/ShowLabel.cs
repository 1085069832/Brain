using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLabel : MonoBehaviour
{
    [SerializeField] Transform[] labels;
    [SerializeField] float speed = 3;
    List<Vector3> defaultScales = new List<Vector3>();
    Vector3 showLabelPos = Vector3.zero;
    float scaleValue;
    [HideInInspector] public bool showlabel;
    [HideInInspector] public bool isShowAll;
    Camera _camera;
    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
        for (int i = 0; i < labels.Length; i++)
        {
            defaultScales.Add(labels[i].localScale);
            labels[i].localScale = Vector3.zero;
            labels[i].parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showlabel || isShowAll)
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
            labels[i].localScale = Mathf.Clamp(scaleValue, 0f, 1f) * defaultScales[i];
            labels[i].LookAt(_camera.transform.position);
            labels[i].Rotate(new Vector3(-90, 0, 180), Space.Self);
        }
    }

    public void InitLabel()
    {
        for (int i = 0; i < labels.Length; i++)
        {
            if (labels.Length < 2 && showLabelPos != Vector3.zero)
            {
                if (showlabel)
                    labels[i].position = showLabelPos;
            }
            labels[i].parent = transform;
        }
    }

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

}
