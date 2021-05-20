using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity;
    [SerializeField] Transform _player;
    [SerializeField] Vector3 _distance;
    Quaternion _initialRotation;
    Quaternion _initialPlayerRotation;
    Rigidbody _rb;
    float angleX = 0;
    float angleY = 0;
    void Start()
    {
        _initialRotation = transform.rotation;
        _initialPlayerRotation = _player.rotation;
        transform.rotation = _player.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        FolowPlayer();
        Turn();
        
    }

    private void FolowPlayer()
    {
        transform.position = _player.position + _distance;
        _player.forward = transform.forward;
        Cursor.lockState = CursorLockMode.Confined;

     
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
       transform.rotation =_initialRotation *  rotationX * rotationY;
       _player.rotation = _initialPlayerRotation * Quaternion.AngleAxis(angleX, Vector3.up);

    }
}
