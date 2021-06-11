using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene1.Turret
{
    public class TurrentBehavior : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _turrel;
        [SerializeField] private Transform _gunPosition;
        [SerializeField] private float _bulletForce;
        [SerializeField] private AudioSource _sound;
        private float _shotDuration = 0.5f;
        private float _bulletLifetime = 3f;
        private Transform _target;
        private bool _isDetected;
        private bool _isShoting = false;
        private void Update()
        {
            if (_isDetected)
            {
                Vector3 direction = _target.position - _turrel.position;
                Quaternion rotate = Quaternion.LookRotation(direction);
                _turrel.rotation = Quaternion.Lerp(rotate, _turrel.rotation, 0.5f);
                if (_turrel.rotation == rotate && !_isShoting)
                {
                    StartCoroutine("Shot");
                }
            }
        }
       private GameObject MakeBullet()
        {
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.position = _gunPosition.position;
            bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            bullet.GetComponent<Renderer>().material.color = Color.red;
            bullet.AddComponent<Rigidbody>();
            Destroy(bullet, _bulletLifetime);
            return bullet;

        }
        private IEnumerator Shot()
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
}