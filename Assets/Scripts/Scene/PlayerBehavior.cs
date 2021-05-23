using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    bool _canJump = false;
    float _dTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dTime = Time.time;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Debug.Log(Input.GetAxis("Vertical"));
            float moveAcceleration = Input.GetAxis("Vertical");
            Vector3 forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            forward *= _speed * moveAcceleration * Time.fixedDeltaTime;
            _rb.MovePosition(transform.position + forward);
            
           
        }
       

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float moveAcceleration = Input.GetAxis("Horizontal");
            Vector3 forward = Camera.main.transform.right * _speed * moveAcceleration * Time.fixedDeltaTime;
            _rb.MovePosition(transform.position + forward);

        }
        if (Input.GetKey(KeyCode.Space) && _canJump)
        {
            _rb.AddForce(Vector3.up * _jump);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
         _canJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }
}
