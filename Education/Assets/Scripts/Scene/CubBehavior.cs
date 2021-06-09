using UnityEngine;

namespace Scene1.Cub
{
    public class CubBehavior : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance;
        private Renderer _mesh;
        private Rigidbody _rb;

        private void Start()
        {
            _mesh = GetComponent<Renderer>();
            _rb = GetComponent<Rigidbody>();
        }

        public void Interact(Vector3 targetPosition, float force)
        {
            if (Vector3.Distance(Camera.main.transform.position, targetPosition) <= _interactionDistance)
            {

                _mesh.material.color = Random.ColorHSV();
                Vector3 clickPoint = targetPosition;
                Vector3 cameraPoint = Camera.main.transform.position;
                Vector3 direction = clickPoint - cameraPoint;
                Debug.DrawLine(cameraPoint, targetPosition, Color.blue, 1);
                direction.Normalize();
                _rb.AddForce(direction * force);               
            }

        }

    }
}
