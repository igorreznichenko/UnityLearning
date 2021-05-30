using UnityEngine;

namespace Scene1.CameraOptions
{
    public class CameraScript : MonoBehaviour
    {
        public float sensitivity;
        [SerializeField] private Vector3 _distance;
        private Quaternion _initialRotation;
        private float angleX = 0;
        private float angleY = 0;
        void Start()
        {
            _initialRotation = transform.rotation;
        }

        private void Update()
        {
            Turn();
        }

        private void Turn()
        {
            float rX = Input.GetAxis("Mouse X") * sensitivity;
            float rY = Input.GetAxis("Mouse Y") * sensitivity;
            angleX += rX;
            angleY += rY;
            angleY = Mathf.Clamp(angleY, -60, 60);
            Quaternion rotationX = Quaternion.AngleAxis(angleX, Vector3.up);
            Quaternion rotationY = Quaternion.AngleAxis(-angleY, Vector3.right);
            transform.rotation = _initialRotation * rotationX * rotationY;
        }
    }

}