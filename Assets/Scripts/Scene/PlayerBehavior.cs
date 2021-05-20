using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] float _force = 20;
    [SerializeField] float _timeDelay = 0.7f;
    bool _canJump = false;
    float _dTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dTime = Time.time;
        Cursor.lockState = CursorLockMode.None;
        UnityEngine.Object[] Objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (var item in Objects)
        {
            if (item.name == "Cylinder")
                Instantiate(item);
        }
        Resources.UnloadUnusedAssets();
        Debug.Log(Objects.Length);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _dTime - Time.time <=0f){
            Fire();
            _dTime = Time.time + _timeDelay;
        }
        Move();
        
    }

    private void Fire()
    {
        RaycastHit raycastHit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray.origin, ray.direction, out raycastHit))
        {
            Rigidbody rigidbody = raycastHit.rigidbody;
            if (rigidbody)
            {
                rigidbody.AddForce((raycastHit.point - Camera.main.transform.position)*_force);
            }
            Debug.DrawLine(Camera.main.transform.position, raycastHit.point);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Debug.Log(Input.GetAxis("Vertical"));
            float moveAcceleration = Input.GetAxis("Vertical");
            Vector3 forward = transform.forward * _speed * moveAcceleration * Time.deltaTime;
            _rb.MovePosition(transform.position + forward);
            Debug.Log("forward: "+transform.forward);
            
           
        }
       

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float moveAcceleration = Input.GetAxis("Horizontal");
            _rb.velocity = transform.right * _speed* moveAcceleration;

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
