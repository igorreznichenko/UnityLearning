using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNormalizedScript : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 _normalized;
    private void Start()
    {
        float magnitude = transform.position.magnitude;
        _normalized = new Vector3(transform.position.x / magnitude, transform.position.y / magnitude, transform.position.z / magnitude);
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(_normalized * Time.deltaTime);
    }
}
