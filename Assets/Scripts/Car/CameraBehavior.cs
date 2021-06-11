using UnityEngine;
namespace Car.CameraOptions
{
    public class CameraBehavior : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 distance;
        [SerializeField] private float translateSpeed;
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            HandleTranslation();
            HandleRotation();

        }
        private void HandleTranslation()
        {
            Vector3 targetPosition = player.TransformPoint(distance);
            transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        }
        private void HandleRotation()
        {
            Vector3 direction = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

    }
}
