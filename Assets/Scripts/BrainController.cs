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
    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
        _camera.transform.LookAt(transform);
    }

    // Update is called once per frame
    void Update()
    {
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (wheelValue != 0)
        {
            offsetPos = _camera.transform.position - transform.position;
            if (offsetPos.magnitude > 0.2f)
            {
                oldPos = _camera.transform.position;
                print("dis" + offsetPos.magnitude);
                offsetPos += wheelValue * wheelSpeed * Time.deltaTime * _camera.transform.forward;
                _camera.transform.position = transform.position + offsetPos;
            }
            else
            {
                _camera.transform.position = oldPos;
            }
        }

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
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
