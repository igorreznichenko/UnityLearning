using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 distance;
    [SerializeField] float translateSpeed;
    [SerializeField] float rotationSpeed;

    void Update()
    {
        HandleTranslation();
       HandleRotation();

    }
    private void HandleTranslation()
    {
        Vector3 targetPosition = player.TransformPoint(distance);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

}
