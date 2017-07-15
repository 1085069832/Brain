using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour
{
    [SerializeField] Transform brain;
    [SerializeField] float scrollSpeed = 300f;
    [SerializeField] float wheelSpeed = 100f;
    [SerializeField] Camera _camera;
    Vector3 offsetPos;
    Vector3 oldPos;
    Vector3 maxOldPos;
    BrainTransparent brainTransparent;
    float disScale;
    [SerializeField] float minDis = 0.1f;
    [SerializeField] float maxDis = 2.5f;
    /// <summary>
    /// 位置的比例值
    /// </summary>
    public float DisScale
    {
        get
        {
            Vector3 disVector = _camera.transform.position - transform.position;
            if (disVector.magnitude <= minDis + 0.1f)
            {
                disScale = 0;
            }
            else
            {
                float disScaleValue = disVector.magnitude / maxDis - 0.4f;
                disScale = Mathf.Clamp(disScaleValue, 0, 1); ;
            }
            return disScale;
        }
    }

    // Use this for initialization
    void Start()
    {
        _camera.transform.LookAt(transform);
        brainTransparent = GetComponent<BrainTransparent>();
    }

    // Update is called once per frame
    void Update()
    {
        float wheelValue = Input.GetAxis(MyConst.MOUSESW);
        if (wheelValue != 0)
        {
            brainTransparent.ChangeMatColor(wheelValue);
            offsetPos = _camera.transform.position - transform.position;
            offsetPos += wheelValue * wheelSpeed * Time.deltaTime * _camera.transform.forward;
            _camera.transform.position = transform.position + offsetPos;
            if (offsetPos.magnitude > minDis)
            {
                oldPos = _camera.transform.position;
            }
            else
            {
                _camera.transform.position = oldPos;
            }

            if (offsetPos.magnitude > maxDis)
            {
                //重置
                _camera.transform.position = maxOldPos;
            }
            else
            {
                //记录位置
                maxOldPos = _camera.transform.position;
            }
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis(MyConst.MOUSEX);
            float mouseY = Input.GetAxis(MyConst.MOUSEY);
            if (mouseX != 0)
            {
                brain.RotateAround(transform.position, transform.up, -mouseX * scrollSpeed * Time.deltaTime);
            }

            if (mouseY != 0)
            {
                brain.RotateAround(transform.position, _camera.transform.right, mouseY * scrollSpeed * Time.deltaTime);
            }
        }
    }
}
