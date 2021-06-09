using UnityEngine;
namespace Scene2.BounceBall
{
    public class BounceBallBehavior : MonoBehaviour
    {
        private int _counter = 0;
        private SphereCollider _sphereCollider;
        private void Start()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }
        private void Update()
        {
            ShowDistance();
        }

        private void ShowDistance()
        {
            var startPoint = _sphereCollider.bounds.center;
            Ray ballRay = new Ray(startPoint, -transform.up);
            RaycastHit raycastHit = new RaycastHit();
            Physics.Raycast(ballRay, out raycastHit);
            float distance = Vector3.Distance(transform.position, raycastHit.point);
            //Debug.Log("Distance: " + distance);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _counter++;
                // Debug.Log(_counter);
            }
        }
    }
}