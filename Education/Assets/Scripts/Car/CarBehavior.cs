using System;
using System.Collections.Generic;
using UnityEngine;
namespace Car
{
    public class CarBehavior : MonoBehaviour
    {
        [SerializeField] float _maxAcceleration = 100;
        [SerializeField] float _corner = 45;
        [SerializeField] List<Wheel> _wheels;
        [SerializeField] Vector3 _centerOfMass;
        float _axisY, _axisX;
        Rigidbody _rb;
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            //rb.centerOfMass = centerOfMass;
        }

        private void Update()
        {
            _axisY = Input.GetAxis("Vertical");
            _axisX = Input.GetAxis("Horizontal");
            AnimateWheels();
        }
        private void LateUpdate()
        {
            Move();
            Turn();
        }

        private void Move()
        {

            foreach (var wheel in _wheels)
            {
                wheel._collider.motorTorque = _maxAcceleration * _axisY * Time.deltaTime;
            }

        }
        void Turn()
        {
            foreach (var wheel in _wheels)
            {
                if (wheel._place == Place.Front)
                    wheel._collider.steerAngle = _corner * _axisX;
            }
        }
        void AnimateWheels()
        {
            Quaternion rotate;
            Vector3 position;
            foreach (var wheel in _wheels)
            {
                wheel._collider.GetWorldPose(out position, out rotate);
                //wheel.wheel.transform.position = position;
                wheel._wheel.transform.rotation = rotate;
            }
        }
    }
}