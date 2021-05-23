using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNormalizedScript : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 _normalized;
    private void Start()
    {

        _normalized = transform.position.normalized;
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(_normalized *_speed* Time.deltaTime);
    }
}
