using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scene1.Trigger
{
    public class TriggerScript : MonoBehaviour
    {
        [SerializeField] float _force = 10f;
        private void OnTriggerStay(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(Vector3.up * _force);
            }
        }
    }
}