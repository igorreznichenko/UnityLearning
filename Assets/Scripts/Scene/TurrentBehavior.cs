using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBehavior : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _turrel;
    [SerializeField] Transform _gunPosition;
    [SerializeField] float _bulletForce;
    [SerializeField] AudioSource _sound;
    float _shotDuration = 0.5f;
    float _bulletLifetime = 3f;
    Transform _target;
    bool _isDetected;
    bool _isShoting = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDetected)
        {
            Vector3 direction = _target.position - _turrel.position;
            Quaternion rotate = Quaternion.LookRotation(direction);
            _turrel.rotation = Quaternion.Lerp(rotate,_turrel.rotation, 0.5f);
            if (_turrel.rotation == rotate && !_isShoting)
            {
                StartCoroutine("Shot");
            }
        } 
    }
    GameObject MakeBullet()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = _gunPosition.position;
        bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bullet.GetComponent<Renderer>().material.color = Color.red;
        bullet.AddComponent<Rigidbody>();
        Destroy(bullet, _bulletLifetime);
        return bullet;
        
    }
    IEnumerator Shot()
    {
        _isShoting = true;
        GameObject bullet = MakeBullet();
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bullet.transform.forward * _bulletForce;
        _sound.Play();
        yield return new WaitForSeconds(_shotDuration);
        _isShoting = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = other.transform;
            _isDetected = true;
            _animator.enabled = false;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isDetected = false;
            _animator.enabled = true;
            _target = null;
        }
    }
}
