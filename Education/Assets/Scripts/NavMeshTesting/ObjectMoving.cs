using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectMoving : MonoBehaviour
{
    [SerializeField] NavMeshAgent _player;
    [SerializeField] Camera _camera;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo))
            {
                _player.SetDestination(hitInfo.point);
            }
        }
    }
}
