using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] float _timeDelay = 0.3f;
    [SerializeField] float _force = 10f;
    [SerializeField] float _shootingDuration = 0.01f;
    [SerializeField] AudioSource _shot;
    LineRenderer _lineRenderer;
    float _dTime;
    Transform _camera;
    void Start()
    {
        _dTime = Time.time + _timeDelay;
        _camera = Camera.main.transform;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _dTime - Time.time <= 0f)
        {
            Shot();
            _dTime = Time.time + _timeDelay;
        }

    }
    void Shot()
    {
        RaycastHit raycastHit;
        Ray ray = new Ray(_camera.position, _camera.transform.forward);
        if (Physics.Raycast(ray.origin, ray.direction, out raycastHit))
        {
            StartCoroutine("ShotEffect");
            Rigidbody rigidbody = raycastHit.rigidbody;
            if (rigidbody)
            {
                rigidbody.AddForce((raycastHit.point - Camera.main.transform.position) * _force);
            }
            CubBehavior cub = raycastHit.collider.GetComponent<CubBehavior>();
            if (cub)
            {
                cub.Interact(raycastHit.point, _force);
            }
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, raycastHit.point);
            
        }
    }
    IEnumerator ShotEffect()
    {
        _shot.Play();
        _lineRenderer.enabled = true;
        yield return new WaitForSeconds(_shootingDuration);
        _lineRenderer.enabled = false;

    }
}
