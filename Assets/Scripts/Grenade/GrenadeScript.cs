using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GrenadeScript : MonoBehaviour
{
    [SerializeField] float _delay = 5f;
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;
    [SerializeField] GameObject _explosionEffect;
    [SerializeField] AudioSource _interaction;
    [SerializeField] AudioSource _explosion;
    [SerializeField] TextMeshProUGUI _timer;
    Renderer _renderer;
    bool _isExplosion = false;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        _delay -= Time.deltaTime;
        if (!_isExplosion)
            _timer.text = String.Format("{0:0}",_delay);
        if(_delay <= 0 && !_isExplosion)
        {
            _timer.text = "";
            Explosion();
        }
        
    }

    private void Explosion()
    {
        _isExplosion = true;
        _explosion.Play();
        Instantiate(_explosionEffect, transform.position,transform.rotation);
        _renderer.enabled = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        
        foreach (var item in colliders)
        {
            Rigidbody Rigidbody = item.GetComponent<Rigidbody>();
            if (Rigidbody)
            {
                Vector3 direction = item.transform.position - transform.position;
                Rigidbody.AddForce(direction * _explosionForce);
            }
        }
        Destroy(gameObject,_explosion.clip.length);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _interaction.Play();
    }
}
