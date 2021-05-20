using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBehavior : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform Turrel;
    [SerializeField] Transform gunPosition;
    [SerializeField] float bulletForce;
    Transform target;
    bool isDetected;
    bool isShoting = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isDetected)
        {
            Vector3 direction = target.position - Turrel.position;
            Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
            Turrel.rotation = Quaternion.Lerp(rotate,Turrel.rotation, 0.7f);
            if (Turrel.rotation == rotate && !isShoting)
            {
                StartCoroutine("Shot");
            }
        } 
    }
    IEnumerator Shot()
    {
        isShoting = true;
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = gunPosition.position;
        bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bullet.GetComponent<Renderer>().material.color = Color.red;
        Rigidbody bulletrb = bullet.AddComponent<Rigidbody>();
        bulletrb.velocity = bullet.transform.forward * bulletForce;

        yield return new WaitForSeconds(0.1f);
        isShoting = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            target = other.transform;
            isDetected = true;
            animator.enabled = false;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            isDetected = false;
            animator.enabled = true;
            target = null;
        }
    }
}
