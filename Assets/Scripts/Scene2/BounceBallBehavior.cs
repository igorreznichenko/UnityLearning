using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBallBehavior : MonoBehaviour
{
    int _counter = 0;
    SphereCollider _sphereCollider;
    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }
    void Update()
    {
        ShowDistance();
    }

    private void ShowDistance()
    {
        var startPoint = _sphereCollider.bounds.center - new Vector3(0, _sphereCollider.radius, 0);

        Ray ballRay = new Ray(startPoint, Vector3.down);
        RaycastHit raycastHit = new RaycastHit();
        Physics.Raycast(ballRay, out raycastHit);
        float distance = Vector3.Distance(transform.position, raycastHit.point);

        //Debug.Log("Distance: " + distance);
    
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _counter++;
           // Debug.Log(_counter);
        }
    }
}
