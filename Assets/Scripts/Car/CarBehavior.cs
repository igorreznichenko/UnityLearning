using System;
using System.Collections.Generic;
using UnityEngine;

public enum Place
{
    Rear,
    Front
}
[Serializable]
public struct Wheel {
    public GameObject wheel;
    public WheelCollider collider;
    public Place place;
}
public class CarBehavior : MonoBehaviour
{
    [SerializeField] float maxAcceleration = 100;
    [SerializeField] float corner = 45;
    [SerializeField] List<Wheel> wheels;
    [SerializeField] Vector3 centerOfMass;
    float axisY, axisX;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     //rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {
       axisY = Input.GetAxis("Vertical");
       axisX = Input.GetAxis("Horizontal");
       AnimateWheels();
    }
    private void LateUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
       
            foreach (var wheel in wheels)
            {
            wheel.collider.motorTorque = maxAcceleration * axisY * 500 * Time.deltaTime;
            }
           
    }
    void Turn()
    {
        foreach (var wheel in wheels)
        { 
            if (wheel.place == Place.Front)
                wheel.collider.steerAngle = corner * axisX;
        }
    }
    void AnimateWheels()
    {
        Quaternion rotate;
        Vector3 position;
        foreach (var wheel in wheels)
        {
            wheel.collider.GetWorldPose(out position, out rotate);
            //wheel.wheel.transform.position = position;
            wheel.wheel.transform.rotation = rotate;
        }
    }
}
