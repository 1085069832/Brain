using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour
{
    [SerializeField] Transform brain;
    [SerializeField] float scrollSpeed = 300f;
    [SerializeField] float wheelSpeed = 100f;
    Camera _camera;
    Vector3 offsetPos;
    Vector3 oldPos;
    Vector3 maxOldPos;
    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
        _camera.transform.LookAt(transform);
    }

    // Update is called once per frame
    void Update()
    {
        float wheelValue = Input.GetAxis(MyConst.MOUSESW);
        if (wheelValue != 0)
        {
            offsetPos = _camera.transform.position - transform.position;
            offsetPos += wheelValue * wheelSpeed * Time.deltaTime * _camera.transform.forward;
            _camera.transform.position = transform.position + offsetPos;
            if (offsetPos.magnitude > 0.2f)
            {
                oldPos = _camera.transform.position;
            }
            else
            {
                _camera.transform.position = oldPos;
            }

            if (offsetPos.magnitude > 2.5f)
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
