using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity;
    [SerializeField] Vector3 _distance;
    Quaternion _initialRotation;
    float angleX = 0;
    float angleY = 0;
    void Start()
    {
        _initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();   
    }


    private void Turn()
    {
        float rX = Input.GetAxis("Mouse X") * sensitivity;
        float rY = Input.GetAxis("Mouse Y") * sensitivity;
        angleX += rX;
        angleY += rY;
        angleY = Mathf.Clamp(angleY, -60, 60);
       Quaternion rotationX = Quaternion.AngleAxis(angleX, Vector3.up);
       Quaternion rotationY = Quaternion.AngleAxis(-angleY, Vector3.right);
       transform.rotation =_initialRotation *rotationX* rotationY;
    }
}
